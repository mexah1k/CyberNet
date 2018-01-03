using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}