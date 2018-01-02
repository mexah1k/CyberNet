using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Abstractions.Repositories.UnitOfWork;
using Database.Core.Context;
using Database.Core.Repositories;
using Database.Core.Repositories.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Team.Api.DependencyInjectionPackages
{
    public class DatabasePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IDatabaseContext, ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IPlayerRepository, PlayerRepository>(Lifestyle.Scoped);
            container.Register<ITeamRepository, TeamRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}