
using Polly;

namespace Weelzy.Test.ThirdPartyAPI.DelegationHandler
{
	public class RetryPolicyHttpDelegationHandler(ILogger<RetryPolicyHttpDelegationHandler> logger) : DelegatingHandler
	{
		private const int RETRY_ATTEMPTS_NUM = 10;
		private readonly ILogger<RetryPolicyHttpDelegationHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return Policy
				.HandleResult<HttpResponseMessage>((response) =>
				{
					if (!response.IsSuccessStatusCode) return false;
					return IsCorrectLotteryNumber(response, request).GetAwaiter().GetResult();
				})
				.WaitAndRetryAsync(RETRY_ATTEMPTS_NUM, retryAttempt => TimeSpan.FromSeconds(1))
				.ExecuteAsync(() => base.SendAsync(request, cancellationToken));
		}

		private async Task<bool> IsCorrectLotteryNumber(HttpResponseMessage response, HttpRequestMessage request)
		{
			var lotteryNumber = int.Parse(await response.Content.ReadAsStringAsync());
			var customerNumber = int.Parse(await request.Content.ReadAsStringAsync());

			return customerNumber != lotteryNumber;
		}
	}
}
