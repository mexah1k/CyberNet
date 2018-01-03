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

        public async Task<IEnumerable<Team>> Get()
        {
            return await context.Teams
                .Include(t => t.Players)
                .ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetPlayers(int teamId)
        {
            var team = await context.Teams.SingleOrDefaultAsync(t => t.Id == teamId);

            return team.Players.ToList();
        }

        public async Task<Player> GetPlayer(int teamId, int playerId)
        {
            var player = await context.Players.SingleOrDefaultAsync(p => p.Id == playerId && p.TeamId == teamId);

            return player;
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