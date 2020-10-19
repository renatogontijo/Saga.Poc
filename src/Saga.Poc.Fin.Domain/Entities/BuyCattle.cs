using Saga.Poc.Domain.Core.DomainObjects;
using Saga.Poc.Saga.Fin.Domain.Validations;
using System;

namespace Saga.Poc.Saga.Fin.Domain.Entities
{
    public class BuyCattle : BaseEntity<BuyCattle>, IAggregateRoot
    {
        protected BuyCattle() :
            base(new BuyCattleValidation())
        {
        }

        public BuyCattle(DateTime buyDate, string supplierName, decimal buyValue)
            : this()
        {
            BuyDate = buyDate;
            SupplierName = supplierName;
            BuyValue = buyValue;

            Validate(this);
        }

        public DateTime BuyDate { get; private set; }

        public string SupplierName { get; private set; }

        public decimal BuyValue { get; private set; }
    }
}
