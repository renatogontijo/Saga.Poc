using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Saga.Poc.Saga.Fin.Repo.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.Repo.Uow
{
    public class UoWTransaction : IUoWTransaction
    {
        private readonly AgroHUBFinContext _context;

        private IDbContextTransaction _transaction = null;

        public UoWTransaction(AgroHUBFinContext context)
        {
            _context = context;
        }

        public async Task BeginAsync()
        {
            if (_transaction == null)
                _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
        }
    }
}