using System.ComponentModel.DataAnnotations;

namespace Tournaments.Data.Contracts.Filters
{
    public class PositionFilter
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}