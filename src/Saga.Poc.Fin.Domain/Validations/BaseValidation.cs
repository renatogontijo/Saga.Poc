using Saga.Poc.Domain.Core.DomainObjects;
using FluentValidation;
using FluentValidation.Results;

namespace Saga.Poc.Saga.Fin.Domain.Validations
{
    public abstract class BaseValidation<T> : AbstractValidator<T>, IEntityValidation<T>
        where T : Entity
    {
        private ValidationResult _validationResult;

        public ValidationResult ValidationResult => _validationResult;

        public bool ValidateEntity(T instance)
        {
            _validationResult = Validate(instance);
            return _validationResult.IsValid;
        }
    }
}
