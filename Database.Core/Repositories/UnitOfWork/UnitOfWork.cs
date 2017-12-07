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

        public ITeamRepository Teams { get; }

        public UnitOfWork(IDatabaseContext context, IUserAccountRepository accounts, ITeamRepository teams)
        {
            this.context = context;
            Accounts = accounts;
            Teams = teams;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}