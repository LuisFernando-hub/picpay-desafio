using Microsoft.AspNetCore.Mvc;
using picpay_desafio.Models.Request;
using picpay_desafio.Services.Transfers;

namespace picpay_desafio.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController: ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> sender(TransactionRequest request)
        {
            var result = await _transactionService.ExecuteAsync(request);

            if (!result.status)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
