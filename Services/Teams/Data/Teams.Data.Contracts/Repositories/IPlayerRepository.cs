using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Teams.Data.Entities;

namespace Teams.Data.Contracts.Repositories
{
    public interface IPlayerRepository : IDisposable
    {
        Task<Player> Get(int id);

        Task<Player> Get(int teamId, int playerId);

        Task<PagedList<Player>> Get(PagingParameter paging);

        Task<PagedList<Player>> Get(PagingParameter paging, int teamId);

        Task AddToTeam(int teamId, int playerId);

        Task RemoveFromTeam(int teamId, int playerId);

        Task Create(Player player, int teamId);

        Task Delete(int id);
    }
}