using Saga.Poc.Saga.Fin.Domain.Entities;
using FluentValidation;

namespace Saga.Poc.Saga.Fin.Domain.Validations
{
    public class BankValidation : BaseValidation<Bank>
    {
        public BankValidation()
        {
            ValidateNumber();
            ValidateName();
        }

        private void ValidateNumber()
        {
            RuleFor(c => c.Number)
                .GreaterThan(0)
                    .WithMessage("Bank number is invalid");
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                    .WithMessage("Bank name must not be empty");
        }
    }
}
