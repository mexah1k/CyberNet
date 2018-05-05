using System.ComponentModel.DataAnnotations;

namespace Teams.Dtos
{
    public class TeamForUpdateDto
    {
        [Required]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }
    }
}