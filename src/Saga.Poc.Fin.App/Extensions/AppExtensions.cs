using Saga.Poc.Saga.Core.Events;
using Saga.Poc.Saga.Fin.App.Commands.Saga;
using Saga.Poc.Saga.Fin.App.Interfaces;
using Saga.Poc.Saga.Fin.App.Saga.Workflows;
using Saga.Poc.Saga.Fin.App.Services;
using Saga.Poc.Saga.Fin.Repo.Extensions;
using Saga.Poc.Saga.Infra.Bus.Rebus.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rebus.ServiceProvider;
using System.Reflection;

namespace Saga.Poc.Saga.Fin.App.Extensions
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
                .RegisterSagaHandler<SagaBuyWorkflow>()
                .RegisterCommandSaga<BuyRegisterSagaCommand>()
                .RegisterIntegrationEvent<CreatedDailyExtractLotEvent>()
                .RegisterIntegrationEvent<UpdatedDailyExtractLotEvent>()
                .RegisterRebus();

            // Services
            services.TryAddScoped<IBankAccountService, BankAccountService>();
            services.TryAddScoped<IBuyCattleService, BuyCattleService>();

            // Repositories
            services.InitilizeContext(configuration["DB_TST"]);
            services.RegisterRepo();

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
