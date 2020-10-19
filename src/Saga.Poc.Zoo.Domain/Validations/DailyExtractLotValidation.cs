using System;
using Saga.Poc.Saga.Zoo.Domain.Entities;
using FluentValidation;

namespace Saga.Poc.Saga.Zoo.Domain.Validations
{
    public class DailyExtractLotValidation : BaseValidation<DailyExtractLot>
    {
        public DailyExtractLotValidation()
        {
            ValidateName();
            ValidateManagementCategoryId();
            ValidateManagementCategoryObj();
            ValidateHeadsAmount();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                    .WithMessage("Daily extract lot name must not be empty");
        }

        private void ValidateManagementCategoryId()
        {
            RuleFor(c => c.ManagementCategoryId)
                .Must(managementCategoryId => managementCategoryId != Guid.Empty)
                    .WithMessage("ManagementCategoryId is invalid");
        }

        private void ValidateManagementCategoryObj()
        {
            RuleFor(c => c.ManagementCategory)
                .NotNull()
                    .WithMessage("ManagementCategory object is invalid");
        }

        private void ValidateHeadsAmount()
        {
            RuleFor(c => c.HeadsAmount)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Amount of heads must be greater than or equal zero");
        }
    }
}
