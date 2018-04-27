using System.ComponentModel.DataAnnotations;
using Teams.Data.Entities.Enum;

namespace Teams.Dtos
{
    public class PlayerForCreationDto
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