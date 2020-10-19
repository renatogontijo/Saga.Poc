using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Saga.Poc.Saga.Fin.Repo.Contexts;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.Repo.Uow
{
    public class UoW : IUoW
    {
        private readonly AgroHUBFinContext _context;
        private IUoWTransaction _uowTransaction = null;

        public UoW(AgroHUBFinContext context)
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
