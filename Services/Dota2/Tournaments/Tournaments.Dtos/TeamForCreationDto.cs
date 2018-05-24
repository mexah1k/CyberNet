using System.ComponentModel.DataAnnotations;

namespace Tournaments.Dtos
{
    public class TeamForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }
    }
}