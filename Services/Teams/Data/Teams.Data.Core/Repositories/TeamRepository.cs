using Infrastructure.Exceptions;
using Infrastructure.Extensions;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Teams.Data.Contracts.Context;
using Teams.Data.Contracts.Repositories;
using Teams.Data.Entities;

namespace Teams.Data.Core.Repositories
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
            Throw.IfNull(team);

            context.Positions.AttachRange(team.Players.Select(p => p.Position));

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
                .SingleAsync(t => t.Id == id);
        }

        public async Task<PagedList<Team>> Get(PagingParameter paging)
        {
            return await context.Teams
                .Include(t => t.Players)
                .ToPaginatedResult(paging);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}