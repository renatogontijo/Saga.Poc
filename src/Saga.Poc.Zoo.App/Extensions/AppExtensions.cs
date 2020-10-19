using Saga.Poc.Saga.Core.Events;
using Saga.Poc.Saga.Infra.Bus.Rebus.Extensions;
using Saga.Poc.Saga.Zoo.App.Interfaces;
using Saga.Poc.Saga.Zoo.App.Services;
using Saga.Poc.Saga.Zoo.Domain.Interfaces.Services;
using Saga.Poc.Saga.Zoo.Domain.Services;
using Saga.Poc.Saga.Zoo.Repo.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Saga.Poc.Saga.Zoo.App.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection RegisterApp(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Bus
            services
                .RegisterAllCommandFromAssembly(assembly)
                .RegisterAllEventsFromAssembly(assembly)
                .RegisterAllHandlersFromAssembly(assembly)
                .RegisterIntegrationEvent<CreateDailyExtractLotEvent>()
                .RegisterRebus();

            // Repositories
            services.InitilizeContext(configuration["DB_TST"]);
            services.RegisterRepo();

            // Services
            services.TryAddScoped<IDailyExtractLotCreateDomainService, DailyExtractLotCreateDomainService>();
            services.TryAddScoped<IDailyExtractLotService, DailyExtractLotService>();

            return services;
        }

        public static IApplicationBuilder ConfigureApp(this IApplicationBuilder app)
        {
            var assembly = Assembly.GetExecutingAssembly();

            app.ConfigureRebus(assembly);

            return app;
        }
    }
}
