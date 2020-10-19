using Saga.Poc.Domain.Core.DomainObjects;
using System;

namespace Saga.Poc.Saga.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
    }
}
