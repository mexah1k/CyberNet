using Database.Entities.Entities;
using System.Threading.Tasks;

namespace Database.Abstractions.Repositories
{
    public interface IPositionsRepository
    {
        Task<Position> Get(int id);
    }
}