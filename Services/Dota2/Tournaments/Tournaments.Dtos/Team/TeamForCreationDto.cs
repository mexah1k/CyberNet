using System.ComponentModel.DataAnnotations;

namespace Tournaments.Dtos.Team
{
    public class TeamForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }
    }
}