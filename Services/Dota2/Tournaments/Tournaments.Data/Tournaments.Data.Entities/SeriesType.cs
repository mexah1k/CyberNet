using Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;
using Tournaments.Data.Entities.Enum;

namespace Tournaments.Data.Entities
{
    public class SeriesType : IKeyIdentifier
    {
        private SeriesType(SeriesTypeEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
        }

        public SeriesType() { }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public static implicit operator SeriesType(SeriesTypeEnum @enum) => new SeriesType(@enum);

        public static implicit operator SeriesTypeEnum(SeriesType seriesType) => (SeriesTypeEnum)seriesType.Id;
    }
}