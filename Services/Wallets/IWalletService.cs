using picpay_desafio.Models.Request;
using picpay_desafio.Models.Response;

namespace picpay_desafio.Services.Wallets
{
    public interface IWalletService
    {
        Task<Result<bool>> ExecuteAsync(WalletRequest request);

    }
}
