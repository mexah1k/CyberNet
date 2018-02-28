using System.Collections.Generic;

namespace Teams.Dtos
{
    public class TeamForCreationDto
    {
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public int Points { get; set; }

        public decimal Revenue { get; set; }

        public ICollection<PlayerForCreationDto> Players { get; set; } = new List<PlayerForCreationDto>();
    }
}