using Infrastructure.Exceptions;
using Infrastructure.Extensions;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.Repositories
{
    public class TournamentRepository : ITournamentsRepository
    {
        private readonly IDataContext context;

        public TournamentRepository(IDataContext context)
        {
            this.context = context;
        }

        public async Task Create(Tournament tournament)
        {
            Throw.IfNull(tournament, nameof(tournament));
            await context.Tournaments.AddAsync(tournament);
        }

        public async Task Delete(int id)
        {
            var tournament = await Get(id);
            context.Tournaments.Remove(tournament);
        }

        public async Task<Tournament> Get(int id)
        {
            return await context.Tournaments
                .Include(t => t.Series)
                .Include(t => t.TeamTournament)
                .ThenInclude(t => t.Team)
                .GetOrThrow(id);
        }

        public async Task<PagedList<Tournament>> Get(PagingParameter paging)
        {
            Throw.IfNull(paging, nameof(paging));

            return await context.Tournaments
                .Include(t => t.Series)
                .Include(t => t.TeamTournament)
                .ThenInclude(t => t.Team)
                .ToPaginatedResult(paging);
        }

        public async Task<PagedList<Team>> GetTeams(int tournamentId, PagingParameter paging)
        {
            Throw.IfNull(paging, nameof(paging));

            return await context.TeamTournament
                .Where(t => t.TournamentId == tournamentId)
                .Select(t => t.Team)
                .ToPaginatedResult(paging);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}