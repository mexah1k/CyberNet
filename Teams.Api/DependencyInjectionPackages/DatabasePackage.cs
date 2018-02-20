using Data.Abstractions.Context;
using Data.Abstractions.Repositories;
using Data.Abstractions.Repositories.UnitOfWork;
using Data.Core.Context;
using Data.Core.Repositories;
using Data.Core.Repositories.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Teams.Api.DependencyInjectionPackages
{
    public class DatabasePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IDatabaseContext, ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IPlayerRepository, PlayerRepository>(Lifestyle.Scoped);
            container.Register<IPositionsRepository, PositionsRepository>(Lifestyle.Scoped);
            container.Register<ITeamRepository, TeamRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}