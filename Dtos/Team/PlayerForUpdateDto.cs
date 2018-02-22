using Data.Entities.Team.Enum;

namespace Dtos.Team
{
    public class PlayerForUpdateDto
    {
        public string NickName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Points { get; set; }

        public string PhotoUrl { get; set; }

        public PositionEnum Position { get; set; }
    }
}