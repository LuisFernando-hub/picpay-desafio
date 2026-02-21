using picpay_desafio.Models.DTOs;
using picpay_desafio.Models.Request;
using picpay_desafio.Models.Response;

namespace picpay_desafio.Services.Transfers
{
    public interface ITransactionService
    {
        Task<Result<TransactionDTO>> ExecuteAsync(TransactionRequest request);
    }
}
