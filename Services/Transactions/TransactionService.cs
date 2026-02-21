using picpay_desafio.Infra.Repository.Transactions;
using picpay_desafio.Infra.Repository.Wallets;
using picpay_desafio.Mappers;
using picpay_desafio.Models;
using picpay_desafio.Models.DTOs;
using picpay_desafio.Models.Enum;
using picpay_desafio.Models.Request;
using picpay_desafio.Models.Response;
using picpay_desafio.Services.Auth;
using picpay_desafio.Services.Notification;
using picpay_desafio.Services.Transfers;

namespace picpay_desafio.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IAuthorizedService _authorizedService;
        private readonly INotificationService _notificationService;

        public TransactionService(ITransactionRepository transactionRepository, IWalletRepository walletRepository, IAuthorizedService authorizedService, INotificationService notificationService)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
            _authorizedService = authorizedService;
            _notificationService = notificationService;
        }

        public async Task<Result<TransactionDTO>> ExecuteAsync(TransactionRequest request)
        {
            if (!await _authorizedService.AuthorizeAsync())
            {
                return Result<TransactionDTO>.error("Invalid Authorization");
            }

            var sender = await _walletRepository.GetById(request.sender_id);
            var receiver = await _walletRepository.GetById(request.receiver_id);

            if (sender == null || receiver == null)
            {
                return Result<TransactionDTO>.error("No wallets found");
            }

            if (sender.amount_account < request.amount || sender.amount_account == 0)
            {
                return Result<TransactionDTO>.error("Insufficient balance");
            }

            if (sender.userType == UserType.lojista)
            {
                return Result<TransactionDTO>.error("Lojista cannot make a transfer.");
            }

            sender.DebitAmount(request.amount);
            receiver.CreditAmount(request.amount);

            var transaction = new TransferenciaEntity(sender.id, receiver.id, request.amount);

            using(var transactionScope = await _transactionRepository.BeginTransactionAsync())
            {
                try
                {
                    var updateTasks = new List<Task>
                    {
                        _walletRepository.UpdateAsync(sender),
                        _walletRepository.UpdateAsync(receiver),
                        _transactionRepository.AddTransaction(transaction)
                    };

                    await Task.WhenAll(updateTasks);

                    await _walletRepository.CommitAsync();
                    await _transactionRepository.CommitAsync();

                    await transactionScope.CommitAsync();
                }
                catch (Exception e)
                {
                    await transactionScope.RollbackAsync();
                    return Result<TransactionDTO>.error("Error transaction: "+ e.Message);
                }
            }

            await _notificationService.SendNotification();
            return Result<TransactionDTO>.success(transaction.ToTransactionDTO());
        }
    }
}
