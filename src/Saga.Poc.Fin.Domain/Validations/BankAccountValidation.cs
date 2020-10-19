using Saga.Poc.Saga.Fin.Domain.Entities;
using FluentValidation;
using System;

namespace Saga.Poc.Saga.Fin.Domain.Validations
{
    public class BankAccountValidation : BaseValidation<BankAccount>
    {
        public BankAccountValidation()
        {
            ValidateBankId();
            ValidateAccountNumber();
            ValidateCustomerName();
        }

        private void ValidateBankId()
        {
            RuleFor(c => c.BankId)
                .Must(bankId => bankId != Guid.Empty)
                    .WithMessage("BankId is invalid");
        }

        private void ValidateAccountNumber()
        {
            RuleFor(c => c.AccountNumber)
                .Matches("[0-9]{1,8}")
                    .WithMessage("Account number is invalid");
        }

        private void ValidateCustomerName()
        {
            RuleFor(c => c.CustomerName)
                .NotEmpty()
                    .WithMessage("Customer name not be empty");
        }
    }
}
