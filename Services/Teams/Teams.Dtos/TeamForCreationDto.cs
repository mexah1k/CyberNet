using System.ComponentModel.DataAnnotations;

namespace Teams.Dtos
{
    public class TeamForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public string LogoUrl { get; set; }
    }
}