using Infrastructure.Extensions;
using System.Linq;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.FilterExtensions
{
    public static class TournamentQueriableExtensions
    {
        public static IQueryable<Tournament> WithFilter(this IQueryable<Tournament> entities, TournamentFilter filter)
        {
            if (filter == null)
                return entities;

            return entities.Where(tournament =>
                tournament.Name.ContainsWithNull(filter.Name) &&
                (tournament.StartDate.GreaterThan(filter.StartDate) || tournament.EndDate.GreaterThan(filter.StartDate)) &&
                (tournament.StartDate.LessThan(filter.EndDate) || tournament.EndDate.LessThan(filter.EndDate)));
        }
    }
}