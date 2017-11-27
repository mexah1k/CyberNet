using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Abstractions.Repositories.UnitOfWork;
using Database.Core.Context;
using Database.Core.Repositories.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Database.Core
{
    public class DatabasePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IUserAccountRepository, IUserAccountRepository>(Lifestyle.Scoped);
            container.Register<IUserTokenRepository, IUserTokenRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IDatabaseContext, ApplicationDbContext>(Lifestyle.Scoped);
        }
    }
}