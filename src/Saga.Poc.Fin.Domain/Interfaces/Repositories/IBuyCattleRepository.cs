using Saga.Poc.Saga.Core.Repositories;
using Saga.Poc.Saga.Fin.Domain.Entities;
using System;

namespace Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories
{
    public interface IBuyCattleRepository : IRepository<BuyCattle>, IDisposable
    {
        BuyCattle GetById(Guid id);

        void Add(BuyCattle buyCattle);

        void Update(BuyCattle buyCattle);
    }
}
