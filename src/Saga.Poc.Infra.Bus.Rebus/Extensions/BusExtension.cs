using Saga.Poc.Saga.Core.Messages;
using Saga.Poc.Saga.Infra.Bus.Handler;
using Saga.Poc.Saga.Infra.Bus.Messages;
using Saga.Poc.Saga.Infra.Bus.Rebus.Messages;
using Saga.Poc.Saga.Infra.Bus.Rebus.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using Rebus.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Rebus.Routing.TypeBased.TypeBasedRouterConfigurationExtensions;
using Rebus.Topic;
using System.Text;

namespace Saga.Poc.Saga.Infra.Bus.Rebus.Extensions
{
    public static class BusExtension
    {
        private static IList<Type> _commands = new List<Type>();
        private static IList<Type> _events = new List<Type>();

        private static void AddRange(this IList<Type> list, IList<Type> items)
        {
            foreach (var item in items)
                list.Add(item);
        }

        public static IServiceCollection RegisterAllCommandFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            _commands.AddRange(LoadAllCommandsFromAssembly(assembly));
            return services;
        }

        public static IServiceCollection RegisterAllEventsFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            _events.AddRange(LoadAllEventsFromAssembly(assembly));
            return services;
        }

        public static IServiceCollection RegisterCommand<TCommand>(this IServiceCollection services)
            where TCommand : Command
        {
            _commands.Add(typeof(TCommand));
            return services;
        }

        public static IServiceCollection RegisterCommandSaga<TCommand>(this IServiceCollection services)
            where TCommand : CommandSaga
        {
            _commands.Add(typeof(TCommand));
            return services;
        }

        public static IServiceCollection RegisterEvent<TEvent>(this IServiceCollection services)
            where TEvent : Event
        {
            _events.Add(typeof(TEvent));
            return services;
        }

        public static IServiceCollection RegisterIntegrationEvent<TEvent>(this IServiceCollection services)
            where TEvent : IntegrationEvent
        {
            _events.Add(typeof(TEvent));
            return services;
        }

        public static IServiceCollection RegisterRebus(this IServiceCollection services)
        {
            var rebusQueue = "rmessages";

            services.AddRebus(config => config
                .Logging(l => l.Console())
                .Transport(t => t.UseRabbitMq("amqp://usr:pwd@localhost:5672/", rebusQueue))
                .Routing(route =>
                {
                    route.TypeBased()
                        .MapAssemblyOf<DomainMessage>(rebusQueue)
                        .MapAssemblyOf<DomainNotification>(rebusQueue)
                        .MapCommands(rebusQueue)
                        .MapEvents(rebusQueue);
                })
                .Sagas(sagas => sagas.StoreInMemory())
                .Options(options =>
                {
                    options.SetNumberOfWorkers(1);
                    options.SetMaxParallelism(1);
                    options.SetBusName("Rebus-Bus");
                })
            );

            services.AutoRegisterHandlersFromAssemblyOf<DomainNotificationHandler>();

            services.TryAddScoped<IBusHandler, RebusHandler>();

            return services;
        }
        public static IServiceCollection RegisterAllHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var handlers = LoadAllHandlersFromAssembly(assembly);

            handlers.ForEach(hdl =>
                services.AutoRegisterHandlersFromAssembly(hdl.Assembly));

            return services;
        }

        public static IServiceCollection RegisterSagaHandler<T>(this IServiceCollection services)
        {
            services.AutoRegisterHandlersFromAssemblyOf<T>();
            return services;
        }

        private static TypeBasedRouterConfigurationBuilder MapCommands(this TypeBasedRouterConfigurationBuilder config, string destinationAddress)
        {
            foreach (var cmd in _commands)
                config.Map(cmd, destinationAddress);

            return config;
        }

        private static TypeBasedRouterConfigurationBuilder MapEvents(this TypeBasedRouterConfigurationBuilder config, string destinationAddress)
        {
            foreach (var evt in _events)
                config.Map(evt, destinationAddress);

            return config;
        }

        private static List<Type> LoadAllCommandsFromAssembly(Assembly assembly)
        {
            var commands = assembly
                .GetTypes()
                .Where(type => type.BaseType == typeof(Command))
                .Select(type => type)
                .ToList();

            return commands;
        }

        private static List<Type> LoadAllEventsFromAssembly(Assembly assembly)
        {
            var events = assembly
                .GetTypes()
                .Where(type => type.BaseType == typeof(Event))
                .Select(type => type)
                .ToList();

            return events;
        }

        private static List<Type> LoadAllHandlersFromAssembly(Assembly assembly)
        {
            var handlers = assembly
                .GetTypes()
                .Where(type => type.BaseType == typeof(CommandHandler))
                .Select(type => type)
                .ToList();

            return handlers;
        }

        private static void SubscribeAllEventsFromAssemby(this IBus bus, Assembly assembly)
        {
            var events = LoadAllEventsFromAssembly(assembly);
            foreach (var evt in events)
                bus.Subscribe(evt).Wait();
        }

        private static void SubscribeAllRegisteredEvents(this IBus bus)
        {
            foreach (var evt in _events)
                bus.Subscribe(evt).Wait();
        }

        public static void SubscribeEvents(this IBus bus, params Type[] events)
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var @event in events)
                bus.Subscribe(@event).Wait();
        }

        public static IApplicationBuilder ConfigureRebus(this IApplicationBuilder app, Assembly assembly)
        {
            app.ApplicationServices.UseRebus(c => {
                c.SubscribeAllRegisteredEvents();
            });

            return app;
        }
    }
}
