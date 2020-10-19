using Saga.Poc.Saga.Core.Repositories;
using Saga.Poc.Saga.Fin.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories
{
    public interface IBankAccountRepository : IRepository<BankAccount>, IDisposable
    {
        Task<BankAccount> GetById(Guid id);

        Task<BankAccount> GetByBankIdAndAccountNumber(Guid bankId, string accountNumber);

        void Add(BankAccount bankAccount);

        void Update(BankAccount bankAccount);
    }
}
