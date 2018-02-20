using Data.Entities.Entities;
using System.Threading.Tasks;

namespace Data.Abstractions.Repositories
{
    public interface IPositionsRepository
    {
        Task<Position> Get(int id);
    }
}