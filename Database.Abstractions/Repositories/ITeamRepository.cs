using Database.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Abstractions.Repositories
{
    public interface ITeamRepository : IDisposable
    {
        Task Create(Team team);

        Task Update(Team team);

        Task Delete(int id);

        Task AddPlayer(int id, Player player);

        Task AddPlayers(int id, IEnumerable<Player> users);

        Task<Team> Get(int id);

        Task<IEnumerable<Team>> Get();

        Task<IEnumerable<Player>> GetPlayers(int id);

        Task<Player> GetPlayer(int teamId, int playerId);
    }
}