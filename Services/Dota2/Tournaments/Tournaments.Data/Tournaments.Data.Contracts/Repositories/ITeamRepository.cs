using Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Contracts.Repositories
{
    public interface ITeamRepository : IDisposable
    {
        Task Create(Team team);

        Task Delete(int id);

        Task<Team> Get(int id);

        Task<PagedList<Team>> Get(PagingParameter paging);

        Task<ICollection<Team>> Get(IEnumerable<int> listIds);

        Task<PagedList<Player>> GetPlayers(int teamId, PagingParameter paging);
    }
}