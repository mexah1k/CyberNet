using Database.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Abstractions.Repositories
{
    public interface ITeamRepository : IDisposable
    {
        Task Create(Team team);

        Task UpdateAsync(Team team);

        Task Delete(int id);

        Task AddTeamate(int id, Player player);

        Task AddTeamates(int id, IEnumerable<Player> users);

        Task<Team> Get(int id);

        Task<IEnumerable<Team>> Get();

        Task<IEnumerable<Player>> GetTeammates(int id);
    }
}