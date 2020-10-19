using Saga.Poc.Saga.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Saga.Poc.Saga.Fin.Repo.Contexts
{
    public class AgroHUBFinContext : DbContext, IDbContext
    {
        public AgroHUBFinContext(DbContextOptions<AgroHUBFinContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
