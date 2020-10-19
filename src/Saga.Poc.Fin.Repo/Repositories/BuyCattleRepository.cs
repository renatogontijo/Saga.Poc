using Saga.Poc.Saga.Fin.Domain.Entities;
using Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Fin.Repo.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Saga.Poc.Saga.Fin.Repo.Repositories
{
    public class BuyCattleRepository : IBuyCattleRepository
    {
        private readonly AgroHUBFinContext Db;

        private readonly DbSet<BuyCattle> DbSet;

        public BuyCattleRepository(AgroHUBFinContext db)
        {
            Db = db;
            DbSet = Db.Set<BuyCattle>();
        }

        public BuyCattle GetById(Guid id)
        {
            return DbSet.FirstOrDefault(i => i.Id == id);
        }

        public void Add(BuyCattle buyCattle)
        {
            DbSet.Add(buyCattle);
        }

        public void Update(BuyCattle buyCattle)
        {
            DbSet.Update(buyCattle);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
