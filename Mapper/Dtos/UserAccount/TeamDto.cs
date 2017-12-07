using System.Collections.Generic;

namespace Mapper.Dtos.UserAccount
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}