using System.Collections.Generic;

namespace Mapper.Dtos.Team
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public decimal Revenue { get; set; }

        public string LogoUrl { get; set; }

        public IEnumerable<PlayerDto> Players { get; set; }
    }
}