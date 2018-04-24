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
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDataContext context;

        public PlayerRepository(IDataContext context)
        {
            this.context = context;
        }

        public async Task<Player> Get(int id)
        {
            return await context.Players
                .Include(p => p.Position)
                .Include(p => p.Team)
                .SingleAsync(u => u.Id == id);
        }

        public async Task<Player> Get(int teamId, int playerId)
        {
            return await context.Players
                .Include(p => p.Position)
                .Include(p => p.Team)
                .SingleAsync(p => p.Id == playerId && p.TeamId == teamId);
        }

        public async Task<PagedList<Player>> Get(PagingParameter paging)
        {
            return await context.Players
                .Include(p => p.Position)
                .Include(p => p.Team)
                .ToPaginatedResult(paging);
        }

        public async Task<PagedList<Player>> Get(PagingParameter paging, int teamId)
        {
            return await context.Players
                .Where(p => p.TeamId == teamId)
                .OrderBy(p => p.Points)
                .ThenBy(p => p.NickName)
                .Include(p => p.Position)
                .Include(p => p.Team)
                .ToPaginatedResult(paging);
        }

        public async Task Create(Player player)
        {
            Throw.IfNull(player);

            if (player.Position != null)
                context.Positions.Attach(player.Position);

            await context.Players.AddAsync(player);
        }

        public async Task AddToTeam(int teamId, int playerId)
        {
            var team = await context.Teams.SingleAsync(t => t.Id == teamId);
            var player = await context.Players.SingleAsync(p => p.Id == playerId);

            team.Players.Add(player);
        }

        public async Task Delete(int id)
        {
            var user = await Get(id);
            context.Players.Remove(user);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}