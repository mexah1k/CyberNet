using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public string NickName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}