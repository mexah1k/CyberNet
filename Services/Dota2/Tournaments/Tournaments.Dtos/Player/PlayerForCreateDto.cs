using System.ComponentModel.DataAnnotations;
using Tournaments.Data.Entities.Enum;

namespace Tournaments.Dtos.Player
{
    public class PlayerForCreateDto
    {
        [Required]
        public string NickName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Points { get; set; }

        public string PhotoUrl { get; set; }

        [Required]
        public PositionEnum Position { get; set; }

        public int TeamId { get; set; }
    }
}