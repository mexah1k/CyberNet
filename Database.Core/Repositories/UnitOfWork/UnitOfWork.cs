using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Abstractions.Repositories.UnitOfWork;
using System.Threading.Tasks;

namespace Database.Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext context;

        public IUserAccountRepository Accounts { get; }

        public UnitOfWork(IDatabaseContext context, IUserAccountRepository accounts)
        {
            this.context = context;
            Accounts = accounts;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}