using Infrastructure.Extensions;
using System.Linq;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.FilterExtensions
{
    public static class PlayerQueriableExtensions
    {
        public static IQueryable<Player> WithFilter(this IQueryable<Player> entities, PlayerFilter filter)
        {
            if (filter == null)
                return entities;

            return entities.Where(player =>
                player.NickName.ContainsWithNull(filter.NickName) &&
                player.FirstName.ContainsWithNull(filter.FirstName) &&
                player.LastName.ContainsWithNull(filter.LastName));
        }
    }
}