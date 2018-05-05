using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Teams.Api.Validators;
using Teams.Data.Core;
using Teams.Domain;

namespace Teams.Api.ApiConfigurations
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
        {
            services
                .AddMvc(setupAction =>
                    {
                        setupAction.ReturnHttpNotAcceptable = true;
                        setupAction.Filters.Add(typeof(ModelStateValidationActionFilter));
                    })
                .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    });

            ConfigureCors(services);
            ConfigureSwagger(services);
            services.AddAutoMapper();
            services
                .RegisterTeamDataServices()
                .RegisterTeamServices();

            RegisterUrlHelper(services);

            return services;
        }

        private static void RegisterUrlHelper(IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper, UrlHelper>(
                implementationFactory =>
                    {
                        var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                        return new UrlHelper(actionContext);
                    });
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Test Teams Api", Version = "v1" }); });
        }

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(
                options =>
                    {
                        options.AddPolicy(
                            "AllowAllCors",
                            builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials(); });
                    });
        }
    }
}