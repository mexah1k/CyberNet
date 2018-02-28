using SimpleInjector;
using SimpleInjector.Packaging;
using Teams.Data.Contracts.Context;
using Teams.Data.Contracts.Repositories;
using Teams.Data.Contracts.Repositories.UnitOfWork;
using Teams.Data.Core.Context;
using Teams.Data.Core.Repositories;
using Teams.Data.Core.Repositories.UnitOfWork;

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