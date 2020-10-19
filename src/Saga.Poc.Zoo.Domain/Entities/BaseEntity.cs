using Saga.Poc.Domain.Core.DomainObjects;
using Saga.Poc.Saga.Zoo.Domain.Validations;
using FluentValidation.Results;

namespace Saga.Poc.Saga.Zoo.Domain.Entities
{
    public abstract class BaseEntity<T> : Entity 
        where T : Entity
    {
        protected BaseValidation<T> _validator;

        protected BaseEntity(BaseValidation<T> validator)
        {
            _validator = validator;
        }

        public ValidationResult ValidationResult => _validator?.ValidationResult;

        protected void Validate(T instance)
        {
            _validator.ValidateEntity(instance);
        }

        public bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
