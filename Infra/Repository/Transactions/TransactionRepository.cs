using Microsoft.EntityFrameworkCore.Storage;
using picpay_desafio.Models;

namespace picpay_desafio.Infra.Repository.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {  
            _context = context;
        }

        public async Task AddTransaction(TransferenciaEntity entityEntity)
        {
            await _context.Transfers.AddAsync(entityEntity);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
