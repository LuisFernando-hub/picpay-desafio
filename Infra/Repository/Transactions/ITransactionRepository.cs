using Microsoft.EntityFrameworkCore.Storage;
using picpay_desafio.Models;

namespace picpay_desafio.Infra.Repository.Transactions
{
    public interface ITransactionRepository
    {
        Task AddTransaction(TransferenciaEntity entityEntity);

        Task CommitAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
