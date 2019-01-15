using Infrastructure.Extensions;
using System.Linq;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.FilterExtensions
{
    public static class PositionQueriableExtensions
    {
        public static IQueryable<Position> WithFilter(this IQueryable<Position> entities, PositionFilter filter)
        {
            if (filter == null)
                return entities;

            return entities.Where(position =>
                position.Name.ContainsWithNull(filter.Name));
        }
    }
}