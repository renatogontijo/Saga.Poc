using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Fin.App.Commands
{
    public class BuyRegisterNewCommand : Command
    {
        protected BuyRegisterNewCommand()
        {
        }

        public BuyRegisterNewCommand(Guid aggregateId, string supplierName, DateTime buyDate, decimal buyValue,
            Guid bankId, string accountNumber, Guid managementCategoryId, int purchasedHeads)
        {
            AggregateId = aggregateId;
            SupplierName = supplierName;
            BuyDate = buyDate;
            BuyValue = buyValue;
            BankId = bankId;
            AccountNumber = accountNumber;
            ManagementCategoryId = managementCategoryId;
            PurchasedHeads = purchasedHeads;
        }

        public BuyRegisterNewCommand(string supplierName, DateTime buyDate, decimal buyValue,
            Guid bankId, string accountNumber, Guid managementCategoryId, int purchasedHeads)
        {
            AggregateId = Guid.NewGuid();
            SupplierName = supplierName;
            BuyDate = buyDate;
            BuyValue = buyValue;
            BankId = bankId;
            AccountNumber = accountNumber;
            ManagementCategoryId = managementCategoryId;
            PurchasedHeads = purchasedHeads;
        }

        public string SupplierName { get; private set; }

        public DateTime BuyDate { get; private set; }

        public decimal BuyValue { get; private set; }

        public Guid BankId { get; private set; }

        public string AccountNumber { get; private set; }

        public Guid ManagementCategoryId { get; private set; }

        public int PurchasedHeads { get; private set; }
    }
}
