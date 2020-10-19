namespace Saga.Poc.Domain.Core.DomainObjects
{
    public interface IEntityValidation<T> where T : class
    {
        bool ValidateEntity(T instance);
    }
}
