using System.Threading.Tasks;

namespace Database.Abstractions.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserAccountRepository Accounts { get; }

        ITeamRepository Teams { get; }

        Task SaveChangesAsync();
    }
}