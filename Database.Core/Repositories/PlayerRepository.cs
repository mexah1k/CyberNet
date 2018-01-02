using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Core.Repositories
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
            return await context.Players.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Player>> Get()
        {
            return await context.Players.ToListAsync();
        }

        public async Task Add(Player player)
        {
            await context.Players.AddAsync(player);
        }

        public async Task Delete(int id)
        {
            var user = await context.Players.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception(); // todo: Add UserNotFoundException

            context.Players.Remove(user);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}