using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Saga.Poc.Saga.Zoo.Repo.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.Repo.Uow
{
    public class UoW : IUoW
    {
        private readonly AgroHUBZooContext _context;
        private IUoWTransaction _uowTransaction = null;

        public UoW(AgroHUBZooContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if (_uowTransaction == null)
            {
                _uowTransaction = new UoWTransaction(_context);
                await _uowTransaction.BeginAsync();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
