using System.Threading.Tasks;

namespace Database.Abstractions.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}