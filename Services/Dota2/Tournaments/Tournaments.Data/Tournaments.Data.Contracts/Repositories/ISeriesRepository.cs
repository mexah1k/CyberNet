using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Contracts.Repositories
{
    public interface ISeriesRepository : IDisposable
    {
        Task<Series> Get(int id);
        Task<PagedList<Series>> Get(PagingParameter paging);
        Task Create(Series series);
        Task Delete(int id);
    }
}