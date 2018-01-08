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

        Task<ICollection<Team>> Get();
    }
}