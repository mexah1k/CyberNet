using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teams.Data.Entities;

namespace Teams.Data.Contracts.Repositories
{
    public interface ITeamRepository : IDisposable
    {
        Task<bool> IsExist(int id);

        Task Create(Team team);

        Task Update(Entities.Team team);

        Task Delete(int id);

        Task<Entities.Team> Get(int id);

        Task<ICollection<Entities.Team>> Get();
    }
}