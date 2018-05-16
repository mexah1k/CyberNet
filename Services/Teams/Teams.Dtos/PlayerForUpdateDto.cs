using System.ComponentModel.DataAnnotations;

namespace Teams.Dtos
{
    public class PlayerForUpdateDto
    {
        [Required]
        public string NickName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Points { get; set; }

        public string PhotoUrl { get; set; }

        public int? PositionId { get; set; }

        public int? TeamId { get; set; }
    }
}