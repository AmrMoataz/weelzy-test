using Microsoft.AspNetCore.Mvc;
using Weelzy.Test.ThirdPartyAPI.Clients;

namespace Weelzy.Test.ThirdPartyAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LotteryController(ILogger<LotteryController> logger, LotteryClient lotteryClient) : ControllerBase
	{
		private readonly ILogger<LotteryController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
		private readonly LotteryClient _lotteryClient = lotteryClient ?? throw new ArgumentNullException(nameof(lotteryClient));

		[HttpGet]
		public async Task<IActionResult> CheckLotteryAsync()
		{
			var customerNumber = new Random().Next(1000, 9999);
			var validLottery = await _lotteryClient.CheckWonLottery(customerNumber);

			return Ok(new
			{
				WonLottery = validLottery 
			});
		}
	}
}
