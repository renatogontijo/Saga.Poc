using System.Threading.Tasks;

namespace Saga.Poc.Saga.Infra.Data.UnitOfWork
{
    public interface IUoW
    {
        Task BeginTransactionAsync();

        Task<bool> SaveChangesAsync();
    }
}
