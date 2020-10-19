using Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Fin.Repo.Contexts;
using Saga.Poc.Saga.Fin.Repo.Repositories;
using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Saga.Poc.Saga.Zoo.Repo.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Saga.Poc.Saga.Fin.Repo.Extensions
{
    public static class RepoExtension
    {
        public static IServiceCollection RegisterRepo(this IServiceCollection services)
        {
            services.TryAddScoped<IUoW, UoW>();

            services.TryAddScoped<IBankAccountRepository, BankAccountRepository>();
            services.TryAddScoped<IBuyCattleRepository, BuyCattleRepository>();

            return services;
        }

        public static IServiceCollection InitilizeContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AgroHUBFinContext>(options => 
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
            services.AddDbContext<AgroHUBFinContext>(options => 
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
