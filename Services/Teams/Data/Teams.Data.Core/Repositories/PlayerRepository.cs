using Infrastructure.Exceptions;
using Infrastructure.Extensions;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
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
                .GetOrThrow(id);
        }

        public async Task<PagedList<Player>> Get(PagingParameter paging)
        {
            Throw.IfNull(paging, nameof(paging));

            return await context.Players
                .Include(p => p.Position)
                .Include(p => p.Team)
                .ToPaginatedResult(paging);
        }

        public async Task Create(Player player)
        {
            Throw.IfNull(player, nameof(player));

            if (player.Position != null)
                context.Positions.Attach(player.Position);

            await context.Players.AddAsync(player);
        }

        public async Task Delete(int id)
        {
            var player = await Get(id);
            context.Players.Remove(player);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}