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

        Task Create(Player player);

        Task Delete(int id);
    }
}