using Microsoft.Extensions.DependencyInjection;
using Tournaments.Domain.Contracts;
using Tournaments.Domain.Services;

namespace Tournaments.Domain
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterTeamServices(this IServiceCollection services)
        {
            services
                .AddScoped<ITeamService, TeamService>()
                .AddScoped<IPlayerService, PlayerService>()
                .AddScoped<IPositionService, PositionService>();

            return services;
        }
    }
}