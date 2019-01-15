using System;
using System.Threading.Tasks;
using Infrastructure.Pagination;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Contracts.Repositories
{
    public interface ISeriesTypeRepository : IDisposable
    {
        Task<SeriesType> Get(int id);
        Task<PagedList<SeriesType>> Get(PagingParameter paging);
    }
}