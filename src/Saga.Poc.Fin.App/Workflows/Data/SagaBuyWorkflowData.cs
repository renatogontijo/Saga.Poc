using Rebus.Sagas;
using System;

namespace Saga.Poc.Saga.Fin.App.Saga.Data
{
    public class SagaBuyWorkflowData : SagaData
    {
        public bool BuyRegistered { get; set; }

        public bool BuyFailed { get; set; }

        public bool BankAccountUpdated { get; set; }

        public bool BankAccountUpdateFailed { get; set; }

        public bool DailyExtractLotRegisted { get; set; }

        public Guid BankId { get; set; }

        public string AccountNumber { get; set; }

        public DateTime BuyDate { get; set; }

        public decimal BuyValue { get; set; }

        public bool Completed => BuyRegistered
                              && BankAccountUpdated
                              && DailyExtractLotRegisted
                              || BuyFailed
                              || BankAccountUpdateFailed;
    }
}
