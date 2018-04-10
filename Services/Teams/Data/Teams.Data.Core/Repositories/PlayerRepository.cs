﻿using Infrastructure.Exceptions;
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
        private readonly IDatabaseContext context;

        public PlayerRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<Player> Get(int id)
        {
            return await context.Players
                .Include(p => p.Position)
                .Include(p => p.Team)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<PagedList<Player>> Get(PagingParameter paging)
        {
            var productList = context.Players
                .Include(p => p.Position)
                .Include(p => p.Team);

            return await productList.ToPaginatedResult(paging);
        }

        public async Task<PagedList<Player>> GetPlayersByTeam(PagingParameter paging, int teamId)
        {
            var players = context.Players
                .Where(p => p.TeamId == teamId)
                .OrderBy(p => p.Points)
                .ThenBy(p => p.NickName)
                .Include(p => p.Position)
                .Include(p => p.Team);

            return await players.ToPaginatedResult(paging);
        }

        public async Task<Player> GetPlayerByTeam(int teamId, int playerId)
        {
            return await context.Players
                .Include(p => p.Position)
                .Include(p => p.Team)
                .SingleOrDefaultAsync(p => p.Id == playerId && p.TeamId == teamId);
        }

        public async Task Add(Player player)
        {
            Throw.IfNull(player);

            if (player.Position != null)
                context.Positions.Attach(player.Position);

            await context.Players.AddAsync(player);
        }

        public async Task Delete(int id)
        {
            var user = await context.Players.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception(); // todo: Add PlayerNotFoundException

            context.Players.Remove(user);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}