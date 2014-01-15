using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dalaran.DAL
{
    public class MysqlRepository : Interfaces.IDataRepository
    {
        private DbContext context;

        public MysqlRepository(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Select<T>( Expression<Func<T, bool>> query) where T : class
        {
            return context.Set<T>().Where(query).AsNoTracking();
        }
    }
}
