using System.Linq;
using Infrastructure.Extensions;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.Filters
{
    public static class TeamQueriableExtensions
    {
        public static IQueryable<Team> WithFilter(this IQueryable<Team> entities, TeamFilter filter)
        {
            if (filter == null)
                return entities;

            return entities.Where(team =>
                team.Name.ContainsIfNotNull(filter.Name) &&
                team.Revenue.EquilIfNull(filter.Revenue));
        }
    }
}