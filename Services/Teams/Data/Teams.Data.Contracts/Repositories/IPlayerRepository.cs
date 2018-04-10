using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Teams.Data.Entities;

namespace Teams.Data.Contracts.Repositories
{
    public interface IPlayerRepository : IDisposable
    {
        Task<Player> Get(int id);

        Task<PagedList<Player>> Get(PagingParameter paging);

        Task<Player> GetPlayerByTeam(int teamId, int playerId);

        Task<PagedList<Player>> GetPlayersByTeam(PagingParameter paging, int teamId);

        Task Add(Player player);

        Task Delete(int id);
    }
}