using System.Reflection;
using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Saga.Poc.Saga.Zoo.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Zoo.Repo.Contexts;
using Saga.Poc.Saga.Zoo.Repo.Repositories;
using Saga.Poc.Saga.Zoo.Repo.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Saga.Poc.Saga.Zoo.Repo.Extensions
{
    public static class RepoExtension
    {
        public static IServiceCollection RegisterRepo(this IServiceCollection services)
        {
            services.TryAddScoped<IUoWTransaction, UoWTransaction>();
            services.TryAddScoped<IUoW, UoW>();

            services.TryAddScoped<IDailyExtractLotRepository, DailyExtractLotRepository>();

            return services;
        }

        public static IServiceCollection InitilizeContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AgroHUBZooContext>(options => 
            {
                options.UseSqlServer(connectionString, sql =>
                {
                    sql.CommandTimeout(240);
                });
            });

            return services;
        }

        public static IServiceCollection InitilizeContext(this IServiceCollection services, string connectionString, string migrationAssembly)
        {
            services.AddDbContext<AgroHUBZooContext>(options => 
            {
                options.UseSqlServer(connectionString, sql =>
                {
                    sql.MigrationsAssembly(migrationAssembly);
                    sql.CommandTimeout(600);
                });
            });

            return services;
        }
    }
}
