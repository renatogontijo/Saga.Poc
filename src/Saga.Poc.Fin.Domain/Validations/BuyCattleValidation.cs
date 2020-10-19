using Saga.Poc.Saga.Fin.Domain.Entities;
using FluentValidation;
using System;

namespace Saga.Poc.Saga.Fin.Domain.Validations
{
    public class BuyCattleValidation : BaseValidation<BuyCattle>
    {
        public BuyCattleValidation()
        {
            ValidateDate();
            ValidateSupplierName();
            ValidateBuyValue();
        }

        private void ValidateDate()
        {
            var now = DateTime.Now.Date;
            var limitDate = now.Date.AddDays(-7);
            RuleFor(c => c.BuyDate.Date)
                .Must(buyDate => limitDate.CompareTo(buyDate) <= 0 && now.CompareTo(buyDate) >= 0)
                    .WithMessage($"Buy Date can't be less than {limitDate:yyyy-MM-dd} or greather than {now:yyyy-MM-dd}");
        }

        private void ValidateSupplierName()
        {
            RuleFor(c => c.SupplierName)
                .NotEmpty()
                    .WithMessage("Suplier name must not be empty");
        }

        private void ValidateBuyValue()
        {
            RuleFor(c => c.BuyValue)
                .GreaterThan(0)
                    .WithMessage("Buy value must be greather than zero");
        }
    }
}
