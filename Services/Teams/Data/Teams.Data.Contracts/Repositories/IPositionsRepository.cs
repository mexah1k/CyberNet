using System.Threading.Tasks;
using Teams.Data.Entities;

namespace Teams.Data.Contracts.Repositories
{
    public interface IPositionsRepository
    {
        Task<Position> Get(int id);
    }
}