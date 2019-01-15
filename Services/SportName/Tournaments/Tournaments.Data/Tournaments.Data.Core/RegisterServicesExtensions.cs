using Microsoft.Extensions.DependencyInjection;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;
using Tournaments.Data.Core.Context;
using Tournaments.Data.Core.Repositories;
using Tournaments.Data.Core.Repositories.UnitOfWork;

namespace Tournaments.Data.Core
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterTeamDataServices(this IServiceCollection services)
        {
            services
                .AddScoped<IDataContext, DataContext>()
                .AddScoped<IPlayerRepository, PlayerRepository>()
                .AddScoped<IPositionRepository, PositionRepository>()
                .AddScoped<ITeamRepository, TeamRepository>()
                .AddScoped<ISeriesRepository, SeriesRepository>()
                .AddScoped<ISeriesTypeRepository, SeriesTypeRepository>()
                .AddScoped<IMatchRepository, MatchRepository>()
                .AddScoped<ITournamentRepository, TournamentRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}