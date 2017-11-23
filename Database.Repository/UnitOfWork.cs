using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext context;
        private readonly IUserAccountRepository accounts;

        public UnitOfWork(IDatabaseContext context, IUserAccountRepository accounts)
        {
            this.context = context;
            this.accounts = accounts;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}