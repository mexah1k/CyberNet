using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities.Entities
{
    public class UserToken
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }

        public User Account { get; set; }

        public string RefreshToken { get; set; }

        public string ResetPasswordToken { get; set; }
    }
}