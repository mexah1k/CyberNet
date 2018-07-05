using System;
using System.Threading.Tasks;
using Infrastructure.Pagination;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Contracts.Repositories
{
    public interface ITournamentRepository : IDisposable
    {
        Task Create(Tournament tournament);
        Task Delete(int id);
        Task<Tournament> Get(int id);
        Task<PagedList<Tournament>> Get(PagingParameter paging);
        Task<PagedList<Team>> GetTeams(int tournamentId, PagingParameter paging);
    }
}