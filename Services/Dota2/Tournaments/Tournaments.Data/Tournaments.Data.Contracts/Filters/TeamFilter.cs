using Infrastructure.Filtering;

namespace Tournaments.Data.Contracts.Filters
{
    public class TeamFilter : Filter
    {
        public string Name { get; set; }

        public decimal? Revenue { get; set; }
    }
}