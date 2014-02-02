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
    public class MysqlRepository : IDataRepository
    {
        private readonly DbContext context;

        public MysqlRepository(DbContext context)
        {
            this.context = context;
            //context.Configuration.LazyLoadingEnabled = false;
        }

        public IQueryable<T> Select<T>( Expression<Func<T, bool>> query, IQueryable<Expression<Func<T, object>>> navigationProperties = null) where T : class, IEntity 
        {
            IQueryable<T> iQuery = context.Set<T>();

            if (navigationProperties != null) 
            { 
                foreach (var property in navigationProperties)
                {
                    iQuery = iQuery.Include(property);
                }
            }

            return iQuery.Where(query).AsNoTracking();
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
