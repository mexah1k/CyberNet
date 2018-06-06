using System.ComponentModel.DataAnnotations;

namespace Tournaments.Dtos.Position
{
    public class PositionDto
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}