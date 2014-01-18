using Dalaran.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Dalaran.DAL.Repositories
{
    public class MysqlRepository : Interfaces.IDataRepository
    {
        private DbContext context;

        public MysqlRepository(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Select<T>( Expression<Func<T, bool>> query) where T : class, IEntity 
        {
            return context.Set<T>().Where(query);
        }

        public void Update<T>(T item) where T : class, IEntity
        {
            DbEntityEntry entry = context.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                context.Set<T>().Attach(item);
            }
            entry.State = EntityState.Modified;
            context.SaveChanges();
        }

        public T Create<T>(T item) where T : class, IEntity
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
            return item;
        }

        public void Delete<T>(T item) where T : class, IEntity
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public void UpdateMany<T>(IEnumerable<T> items) where T : class, IEntity
        {
            foreach(var item in items)
            {
                DbEntityEntry entry = context.Entry(item);
                if (entry.State == EntityState.Detached)
                {
                    context.Set<T>().Attach(item);
                }
                entry.State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public IEnumerable<T> CreateMany<T>(IEnumerable<T> items) where T : class, IEntity
        {
            foreach(var item in items)
            {
                context.Set<T>().Add(item);
            }
            context.SaveChanges();
            return items;
        }

        public void DeleteMany<T>(IEnumerable<T> items) where T : class, IEntity
        {
            foreach (var item in items)
            {
                context.Set<T>().Remove(item);
            }
            context.SaveChanges();
        }
    }
}
