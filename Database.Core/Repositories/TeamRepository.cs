using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Core.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IDatabaseContext context;

        public TeamRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsExist(int id)
        {
            return await context.Teams.AnyAsync(t => t.Id == id);
        }

        public async Task Create(Team team)
        {
            await context.Teams.AddAsync(team);
        }

        public async Task Delete(int id)
        {
            var team = await context.Teams.SingleOrDefaultAsync(t => t.Id == id);

            if (team == null)
                throw new Exception(); // todo: custom exception

            context.Teams.Remove(team);
        }

        public async Task<Team> Get(int id)
        {
            return await context.Teams
                .Include(t => t.Players)
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ICollection<Team>> Get()
        {
            return await context.Teams
                .Include(t => t.Players)
                .ToListAsync();
        }

        public async Task AddPlayer(int id, Player player)
        {
            throw new NotImplementedException();
        }

        public async Task AddPlayers(int id, IEnumerable<Player> users)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Team updatedTeam)
        {
            // todo: implement
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}