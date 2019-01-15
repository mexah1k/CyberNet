using Infrastructure.Filtering;
using System.ComponentModel.DataAnnotations;

namespace Tournaments.Data.Contracts.Filters
{
    public class TeamFilter : IFilter
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal? Revenue { get; set; }
    }
}