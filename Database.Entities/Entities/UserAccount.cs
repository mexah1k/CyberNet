using System.ComponentModel.DataAnnotations;

namespace Database.Entities.Entities
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string NickName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}