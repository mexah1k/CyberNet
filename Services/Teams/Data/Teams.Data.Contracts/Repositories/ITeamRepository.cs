using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Teams.Data.Entities;

namespace Teams.Data.Contracts.Repositories
{
    public interface ITeamRepository : IDisposable
    {
        Task<bool> IsExist(int id);

        Task Create(Team team);

        Task Delete(int id);

        Task<Team> Get(int id);

        Task<PagedList<Team>> Get(PagingParameter paging);
    }
}