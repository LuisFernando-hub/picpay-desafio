using Microsoft.EntityFrameworkCore;
using picpay_desafio.Models;

namespace picpay_desafio.Infra.Repository.Wallets
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _context; 
        public WalletRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CarteiraEntity wallet)
        {
            await _context.AddAsync(wallet);
        }

        public async Task UpdateAsync(CarteiraEntity wallet)
        {
            _context.Update(wallet);
        }

        public async Task<CarteiraEntity?> GetByDocument(string document, string email)
        {
            return await _context.Wallets.FirstOrDefaultAsync(wallet => 
                wallet.document.Equals(document) && wallet.email.Equals(email)
            );
        }

        public async Task<CarteiraEntity?> GetById(int id)
        {
            return await _context.Wallets.FindAsync(id);
        }


        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
