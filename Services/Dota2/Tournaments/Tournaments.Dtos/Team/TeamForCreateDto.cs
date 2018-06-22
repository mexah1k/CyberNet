using System.ComponentModel.DataAnnotations;

namespace Tournaments.Dtos.Team
{
    public class TeamForCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }
    }
}