using System.ComponentModel.DataAnnotations;

namespace Mapper.Dtos.Team
{
    public class TeamForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public string LogoUrl { get; set; }
    }
}