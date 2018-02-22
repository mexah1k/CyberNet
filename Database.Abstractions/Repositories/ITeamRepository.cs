using Data.Entities.Team;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Abstractions.Repositories
{
    public interface ITeamRepository : IDisposable
    {
        Task<bool> IsExist(int id);

        Task Create(Team team);

        Task Update(Team team);

        Task Delete(int id);

        Task<Team> Get(int id);

        Task<ICollection<Team>> Get();
    }
}