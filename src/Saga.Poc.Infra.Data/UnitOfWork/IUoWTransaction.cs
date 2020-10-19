using System;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Infra.Data.UnitOfWork
{
    public interface IUoWTransaction : IDisposable
    {
        Task BeginAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}
