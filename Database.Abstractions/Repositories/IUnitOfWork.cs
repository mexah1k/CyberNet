using System.Threading.Tasks;

namespace Database.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}