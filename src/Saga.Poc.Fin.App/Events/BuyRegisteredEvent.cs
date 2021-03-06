using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Core.Events
{
    public class BuyRegisteredEvent : Event
    {
        public BuyRegisteredEvent(Guid aggregateId, Guid buyCattleId, string supplierName, DateTime buyDate,
            decimal buyValue, Guid bankId, string accountNumber,
            Guid managementCategoryId, int purchasedHeads)
        {
            AggregateId = aggregateId;
            BuyCattleId = buyCattleId;
            SupplierName = supplierName;
            BuyDate = buyDate;
            BuyValue = buyValue;
            BankId = bankId;
            AccountNumber = accountNumber;
            ManagementCategoryId = managementCategoryId;
            PurchasedHeads = purchasedHeads;
        }

        public Guid BuyCattleId { get; private set; }

        public string SupplierName { get; private set; }

        public DateTime BuyDate { get; private set; }

        public decimal BuyValue { get; private set; }

        public Guid BankId { get; private set; }

        public string AccountNumber { get; private set; }

        public Guid ManagementCategoryId { get; private set; }

        public int PurchasedHeads { get; private set; }
    }
}
