using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Saga.Poc.Saga.Zoo.Repo.Contexts
{
    public class AgroHUBZooContext : DbContext
    {
        public AgroHUBZooContext(DbContextOptions<AgroHUBZooContext> options) :
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
