using Microsoft.AspNetCore.Mvc;
using picpay_desafio.Models.Enum;
using picpay_desafio.Models.Request;
using picpay_desafio.Models.Response;
using picpay_desafio.Services.Wallets;

namespace picpay_desafio.Controllers
{
    [ApiController]
    [Route("api/wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpPost]
        public async Task<IActionResult> store(WalletRequest request)
        {
            var result = await _walletService.ExecuteAsync(request);

            if (!result.status)
            {
                return BadRequest(result);
            }

            return Created();
        }
    }
}
