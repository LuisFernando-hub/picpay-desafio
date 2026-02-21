using picpay_desafio.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace picpay_desafio.Models.Request
{
    public class WalletRequest
    {
        [Required(ErrorMessage = "The name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "The document is required")]
        public string document {  get; set; }

        [Required(ErrorMessage = "The email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        public string password { get; set; }

        [Required(ErrorMessage = "The type user is required")]
        public string user_type { get; set; }

        [Required(ErrorMessage = "The Amount is required")]
        public decimal amount_account { get; set; }
    }
}
