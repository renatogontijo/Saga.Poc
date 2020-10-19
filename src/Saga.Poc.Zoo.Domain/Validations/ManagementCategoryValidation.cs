using Saga.Poc.Saga.Zoo.Domain.Entities;
using FluentValidation;

namespace Saga.Poc.Saga.Zoo.Domain.Validations
{
    public class ManagementCategoryValidation : BaseValidation<ManagementCategory>
    {
        public ManagementCategoryValidation()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                    .WithMessage("Name is empty");
        }
    }
}
