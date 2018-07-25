using Infrastructure.Exceptions;
using Infrastructure.Extensions;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Core.FilterExtensions;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IDataContext context;

        public TeamRepository(IDataContext context)
        {
            this.context = context;
        }

        public async Task Create(Team team)
        {
            Throw.IfNull(team, nameof(team));
            await context.Teams.AddAsync(team);
        }

        public async Task Delete(int id)
        {
            var team = await Get(id);
            context.Teams.Remove(team);
        }

        public async Task<Team> Get(int id)
        {
            return await context.Teams
                .Include(t => t.Players)
                .GetOrThrow(id);
        }

        public async Task<PagedList<Team>> Get(PagingParameter paging, TeamFilter filters)
        {
            Throw.IfNull(paging, nameof(paging));

            return await context.Teams
                .Include(t => t.Players)
                .WithFilter(filters)
                .ToPaginatedResult(paging);
        }

        public async Task<ICollection<Team>> Get(IEnumerable<int> listIds)
        {
            Throw.IfNull(listIds, nameof(listIds));

            return await context.Teams
                .Where(t => listIds.Contains(t.Id))
                .Include(t => t.Players)
                .ToListAsync();
        }

        public async Task<PagedList<Player>> GetPlayers(int teamId, PagingParameter paging)
        {
            Throw.IfNull(paging, nameof(paging));

            return await context.Players
                .Where(p => p.TeamId == teamId)
                .ToPaginatedResult(paging);
        }

        public async Task<PagedList<Tournament>> GetTournaments(int teamId, PagingParameter paging)
        {
            Throw.IfNull(paging, nameof(paging));

            return await context.TeamTournament
                .Where(t => t.TeamId == teamId)
                .Select(t => t.Tournament)
                .ToPaginatedResult(paging);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}