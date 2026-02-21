namespace picpay_desafio.Models
{
    public class TransferenciaEntity
    {
        public Guid transaction_id { get; set; }
        public int sender_id { get; set; }
        public CarteiraEntity sender { get; set; }

        public int receiver_id { get; set; }
        public CarteiraEntity receiver { get; set; }

        public decimal amount { get; set; }

        private TransferenciaEntity() { }   

        public TransferenciaEntity(int sender_id, int receiver_id, decimal amount)
        {
            this.transaction_id = Guid.NewGuid();
            this.sender_id = sender_id;
            this.receiver_id = receiver_id;
            this.amount = amount;
        }
    }
}
