using picpay_desafio.Models;

namespace picpay_desafio.Infra.Repository.Wallets
{
    public interface IWalletRepository
    {
        Task AddAsync(CarteiraEntity wallet);
        Task UpdateAsync (CarteiraEntity wallet);
        Task<CarteiraEntity?> GetByDocument(string document, string email);
        Task<CarteiraEntity?> GetById(int id);
        Task CommitAsync();

    }
}
