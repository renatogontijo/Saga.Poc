using Saga.Poc.Domain.Core.DomainObjects;
using Saga.Poc.Saga.Zoo.Domain.Validations;
using System;

namespace Saga.Poc.Saga.Zoo.Domain.Entities
{
    public class DailyExtractLot : BaseEntity<DailyExtractLot>, IAggregateRoot
    {
        protected DailyExtractLot() :
            base(new DailyExtractLotValidation())
        {
        }

        public DailyExtractLot(string name, Guid managementCategoryId, int headAmount) :
            this()
        {
            Name = name;
            ManagementCategoryId = managementCategoryId;
            HeadsAmount = headAmount;

            Validate(this);
        }

        public string Name { get; private set; }

        public int HeadsAmount { get; private set; }

        public Guid ManagementCategoryId { get; private set; }

        public ManagementCategory ManagementCategory { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;

            Validate(this);
        }

        public void ChangeManagementCategory(ManagementCategory managementCategory)
        {
            ManagementCategory = managementCategory;
            ManagementCategoryId = managementCategory.Id;

            Validate(this);
        }

        public bool HasEnoughHeadsToDecrease(int numberToDecrease)
        {
            return ((HeadsAmount - numberToDecrease) >= 0);
        }

        public void IncreateHeadsAmount(int heads)
        {
            HeadsAmount += heads;

            Validate(this);
        }

        public void DecreaseHeadsAmount(int heads)
        {
            HeadsAmount -= heads;

            Validate(this);
        }
    }
}
