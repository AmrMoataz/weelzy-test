
namespace Weelzy.Test.ThirdPartyAPI.Clients
{
	public class LotteryClient(HttpClient httpClient, ILogger<LotteryClient> logger)
	{
		private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		private readonly ILogger<LotteryClient> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

		public async Task<bool> CheckWonLottery(int customerNumber)
		{
			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "");
			httpRequestMessage.Content = new StringContent(customerNumber.ToString());
			var response = await _httpClient.SendAsync(httpRequestMessage);

			if (!response.IsSuccessStatusCode)
			{
				return false;
			}

			var lotteryResult = int.Parse(await response.Content.ReadAsStringAsync());
			return customerNumber == lotteryResult;
		}
	}
}
