using System.Threading.Tasks;

namespace Database.Abstractions.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPlayerRepository Players { get; }

        ITeamRepository Teams { get; }

        Task<bool> SaveChangesAsync();
    }
}