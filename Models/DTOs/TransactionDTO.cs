namespace picpay_desafio.Models.DTOs
{
    public record TransactionDTO(Guid transaction_id, CarteiraEntity sender, CarteiraEntity receiver, decimal amount);
}
