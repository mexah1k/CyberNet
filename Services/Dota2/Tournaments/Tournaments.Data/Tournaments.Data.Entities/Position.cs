using Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;
using Tournaments.Data.Entities.Enum;

namespace Tournaments.Data.Entities
{
    public class Position : IKeyIdentifier
    {
        private Position(PositionEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
        }

        public Position() { }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public static implicit operator Position(PositionEnum @enum) => new Position(@enum);

        public static implicit operator PositionEnum(Position position) => (PositionEnum)position.Id;
    }
}
