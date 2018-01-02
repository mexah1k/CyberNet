using System.Collections.Generic;

namespace Mapper.Dtos.Team
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<PlayerDto> Players { get; set; }
    }
}