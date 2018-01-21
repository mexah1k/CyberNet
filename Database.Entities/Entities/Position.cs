using System.ComponentModel.DataAnnotations;

namespace Database.Entities.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
