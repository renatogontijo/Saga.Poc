using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Fin.App.Commands
{
    public class CreateNewBankAccountCommand : Command
    {
        protected CreateNewBankAccountCommand()
        {
        }

        public CreateNewBankAccountCommand(Guid bankId, string accountNumber,
            string customerName, decimal initialBalance)
        {
            AggregateId = Guid.NewGuid();
            BankId = bankId;
            AccountNumber = accountNumber;
            CustomerName = customerName;
            InitialBalance = initialBalance;
        }

        public Guid BankId { get; private set; }

        public string AccountNumber { get; private set; }

        public string CustomerName { get; private set; }

        public decimal InitialBalance { get; private set; }
    }
}
