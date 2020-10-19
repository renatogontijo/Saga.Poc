using Saga.Poc.Saga.Zoo.Domain.Validations;

namespace Saga.Poc.Saga.Zoo.Domain.Entities
{
    public class ManagementCategory : BaseEntity<ManagementCategory>
    {
        protected ManagementCategory() :
            base(new ManagementCategoryValidation())
        {
        }

        public ManagementCategory(string name) :
            this()
        {
            Name = name;

            Validate(this);
        }

        public string Name { get; private set; }
    }
}
