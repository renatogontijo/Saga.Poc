using Saga.Poc.Saga.Fin.Domain.Entities;
using Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Fin.Repo.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.Repo.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly AgroHUBFinContext Db;

        private readonly DbSet<BankAccount> DbSet;

        public BankAccountRepository(AgroHUBFinContext db)
        {
            Db = db;
            DbSet = Db.Set<BankAccount>();
        }

        public async Task<BankAccount> GetById(Guid id)
        {
            return await DbSet
                .Include(i => i.Bank)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<BankAccount> GetByBankIdAndAccountNumber(Guid bankId, string accountNumber)
        {
            return await DbSet
                .Include(i => i.Bank)
                .FirstOrDefaultAsync(i => i.BankId == bankId
                                       && i.AccountNumber == accountNumber);
        }

        public void Add(BankAccount bankAccount)
        {
            DbSet.Add(bankAccount);
        }

        public void Update(BankAccount bankAccount)
        {
            DbSet.Update(bankAccount);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
