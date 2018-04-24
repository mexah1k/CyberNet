using Microsoft.Extensions.DependencyInjection;
using Teams.Data.Contracts.Context;
using Teams.Data.Contracts.Repositories;
using Teams.Data.Contracts.Repositories.UnitOfWork;
using Teams.Data.Core.Context;
using Teams.Data.Core.Repositories;
using Teams.Data.Core.Repositories.UnitOfWork;

namespace Teams.Data.Core
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterTeamDataServices(this IServiceCollection services)
        {
            services
                .AddScoped<IDataContext, DataContext>()
                .AddScoped<IPlayerRepository, PlayerRepository>()
                .AddScoped<IPositionsRepository, PositionsRepository>()
                .AddScoped<ITeamRepository, TeamRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}