using picpay_desafio.Models;
using picpay_desafio.Models.DTOs;

namespace picpay_desafio.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDTO ToTransactionDTO(this TransferenciaEntity transaction)
        {
            return new TransactionDTO(
                    transaction.transaction_id,
                    transaction.sender,
                    transaction.receiver,
                    transaction.amount
                );
        }
    }
}
