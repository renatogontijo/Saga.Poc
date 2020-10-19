using System;

namespace Saga.Poc.Saga.Fin.App.Requests
{
    public class BuyCattleRegisterNewRequest
    {
        public string SupplierName { get; set; }

        public DateTime BuyDate { get; set; }

        public decimal BuyValue { get; set; }

        public Guid BankId { get; set; }

        public string AccountNumber { get; set; }

        public Guid ManagementCategoryId { get; set; }

        public int PurchasedHeads { get; set; }
    }
}
