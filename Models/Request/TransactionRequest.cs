using System.ComponentModel.DataAnnotations;

namespace picpay_desafio.Models.Request
{
    public class TransactionRequest
    {
        [Required(ErrorMessage = "The amount is required")]
        [Range(500, double.MaxValue, ErrorMessage = "The amount must be greater than 500")]
        public decimal amount { get; set; }

        [Required(ErrorMessage = "The sender_id is required")]
        public int sender_id { get; set; }

        [Required(ErrorMessage = "The receive_id is required")]
        public int receiver_id { get; set; }
    }
}
