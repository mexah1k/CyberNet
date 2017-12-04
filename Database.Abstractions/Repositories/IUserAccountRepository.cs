using Database.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Abstractions.Repositories
{
    public interface IUserAccountRepository : IDisposable
    {
        Task<User> Get(int id);
        Task<IEnumerable<User>> Get();
        Task Add(User user);
        Task Delete(int id);
    }
}