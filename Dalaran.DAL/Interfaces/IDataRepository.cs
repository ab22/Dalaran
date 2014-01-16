using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dalaran.DAL.Interfaces
{
    public interface IDataRepository
    {
        IQueryable<T> Select<T>(Expression<Func<T, bool>> query) where T: class, IEntity;

    }
}
