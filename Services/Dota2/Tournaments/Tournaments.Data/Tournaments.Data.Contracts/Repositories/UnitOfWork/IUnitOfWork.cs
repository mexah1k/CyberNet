using System;
using System.Threading.Tasks;

namespace Tournaments.Data.Contracts.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }

        ITeamRepository Teams { get; }

        IPositionsRepository Positions { get; }

        Task<bool> SaveChangesAsync();
    }
}