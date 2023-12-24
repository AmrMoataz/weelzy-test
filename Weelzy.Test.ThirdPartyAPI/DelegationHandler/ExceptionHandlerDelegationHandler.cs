
using System.Net.Mime;
using System.Net;
using System.Text;

namespace Weelzy.Test.ThirdPartyAPI.DelegationHandler
{
	public class ExceptionHandlerDelegationHandler(ILogger<ExceptionHandlerDelegationHandler> logger) : DelegatingHandler
	{
		private readonly ILogger<ExceptionHandlerDelegationHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			try
			{
				return await base.SendAsync(request, cancellationToken);
			}
			catch (Exception exception)
			{
				var errorMessage = exception.Message ?? string.Empty;
				_logger.LogError(exception, "Error in sending {url}/{ExceptionMessage}/{StackTrace}/{@Exception}", request.RequestUri, errorMessage, exception.StackTrace, exception);
				var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(exception.StackTrace, Encoding.UTF8, MediaTypeNames.Text.Plain),
					ReasonPhrase = errorMessage.Substring(0, Math.Min(errorMessage.Length, 128)), // ReasonPhrase has a max length of 128 chars
				};
				return response;
			}
		}
	}
}
