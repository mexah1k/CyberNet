using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Database.Core.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly IDatabaseContext context;

        public UserAccountRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<UserAccount> Get(int id)
        {
            return await context.UsersAccounts.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async void Add(UserAccount userAccount)
        {
            await context.UsersAccounts.AddAsync(userAccount);
        }

        public async void Delete(int id)
        {
            var user = await context.UsersAccounts.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception(); // todo: Add UserNotFoundException

            context.UsersAccounts.Remove(user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}