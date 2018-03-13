using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teams.Dtos
{
    public class TeamForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public decimal Revenue { get; set; }

        public ICollection<PlayerForCreationDto> Players { get; set; } = new List<PlayerForCreationDto>();
    }
}