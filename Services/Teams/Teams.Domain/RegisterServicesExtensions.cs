using Microsoft.Extensions.DependencyInjection;
using Teams.Domain.Contracts;
using Teams.Domain.Services;

namespace Teams.Domain
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterTeamServices(this IServiceCollection services)
        {
            services
                .AddScoped<ITeamService, TeamService>()
                .AddScoped<IPlayerService, PlayerService>();

            return services;
        }
    }
}