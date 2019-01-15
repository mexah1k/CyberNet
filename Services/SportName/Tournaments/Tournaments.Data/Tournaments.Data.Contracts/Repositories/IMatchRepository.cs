using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Contracts.Repositories
{
    public interface IMatchRepository : IDisposable
    {
        Task<Match> Get(int id);

        Task<PagedList<Match>> Get(PagingParameter paging);

        Task Create(Match match);

        Task Delete(int id);
    }
}