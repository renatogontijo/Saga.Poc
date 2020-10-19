using System;
using Saga.Poc.Domain.Core.DomainObjects;
using Saga.Poc.Saga.Fin.Domain.Validations;

namespace Saga.Poc.Saga.Fin.Domain.Entities
{
    public class BankAccount : BaseEntity<BankAccount>, IAggregateRoot
    {
        public BankAccount() :
            base(new BankAccountValidation())
        {
        }

        public BankAccount(Guid bankId, string accountNumber, string customerName, decimal balance) :
            this()
        {
            BankId = bankId;
            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = balance;
            Active = true;

            Validate(this);
        }

        public string AccountNumber { get; private set; }

        public string CustomerName { get; private set; }

        public decimal Balance { get; private set; }

        public bool Active { get; private set; }

        public Guid BankId { get; private set; }

        public Bank Bank { get; private set; }

        public void InactivateAccount()
        {
            Active = false;
        }

        public void ReactivateAccount()
        {
            Active = true;
        }

        public void IncreaseBalance(decimal value)
        {
            Balance += value;
        }

        public void DecreaseBalance(decimal value)
        {
            Balance -= value;
        }

        public bool HasEnoughBalance(decimal value)
        {
            var verifyBalance = Balance - value;
            return (verifyBalance >= 0);
        }
    }
}
