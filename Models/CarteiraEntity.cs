using picpay_desafio.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace picpay_desafio.Models
{
    public class CarteiraEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string document {  get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public decimal amount_account { get; set; }
        [Column("user_type")]
        public UserType userType { get; set; }

        private CarteiraEntity() { }

        public CarteiraEntity(string name, string document, string email, string password, UserType userType, decimal amountAccount = 0)
        {
            this.name = name;
            this.document = document;
            this.email = email;
            this.password = password;
            this.amount_account = amountAccount;
            this.userType = userType;
        }

        public void DebitAmount(decimal amount)
        {
            this.amount_account -= amount;
        }

        public void CreditAmount(decimal amount)
        {
            this.amount_account += amount;
        }
    }

}
