using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Database.Entities.Entities;

namespace Mapper.Dtos.Team
{
    public class TeamForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public int Points { get; set; }

        public decimal Revenue { get; set; }

        public ICollection<PlayerForCreationDto> Players { get; set; } = new List<PlayerForCreationDto>();
    }
}