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

        public string PhotoUrl { get; set; }
        
        public int Points { get; set; }

        public decimal Revenue { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}