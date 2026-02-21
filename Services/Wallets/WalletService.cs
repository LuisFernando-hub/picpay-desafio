using Microsoft.AspNetCore.Http.HttpResults;
using picpay_desafio.Infra.Repository.Wallets;
using picpay_desafio.Models;
using picpay_desafio.Models.Enum;
using picpay_desafio.Models.Request;
using picpay_desafio.Models.Response;

namespace picpay_desafio.Services.Wallets
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Result<bool>> ExecuteAsync(WalletRequest request)
        {
            var checkWallet = await _walletRepository.GetByDocument(request.document, request.email);

            if (checkWallet != null)
            {
                return Result<bool>.error("The wallet already exists.");
            }

            var userType = Enum.Parse<UserType>(request.user_type);

            var wallet = new CarteiraEntity(
                    request.name,
                    request.document,
                    request.email,
                    request.password,
                    userType,
                    request.amount_account
                );

            await _walletRepository.AddAsync(wallet);

            await _walletRepository.CommitAsync();

            return Result<bool>.success(true);      
        }
    }
}
