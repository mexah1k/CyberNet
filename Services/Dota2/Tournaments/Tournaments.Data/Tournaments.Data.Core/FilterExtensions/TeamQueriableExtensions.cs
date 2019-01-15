using Infrastructure.Extensions;
using System.Linq;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.FilterExtensions
{
    public static class TeamQueriableExtensions
    {
        public static IQueryable<Team> WithFilter(this IQueryable<Team> entities, TeamFilter filter)
        {
            if (filter == null)
                return entities;

            return entities.Where(team =>
                team.Name.ContainsWithNull(filter.Name) &&
                team.Revenue.EqualWithNull(filter.Revenue));
        }
    }
}