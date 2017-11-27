using Database.Entities.Entities;
using System;
using System.Threading.Tasks;

namespace Database.Abstractions.Repositories
{
    public interface IUserAccountRepository : IDisposable
    {
        Task<User> Get(int id);
    }
}