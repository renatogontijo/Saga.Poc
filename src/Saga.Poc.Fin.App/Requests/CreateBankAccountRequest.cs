using System;

namespace Saga.Poc.Saga.Fin.App.Requests
{
    public class CreateBankAccountRequest
    {
        public string AccountNumber { get; set; }

        public string CustomerName { get; set; }

        public decimal InitialBalance { get; set; }

        public Guid BankId { get; set; }
    }
}
