﻿using System;
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
        void Update<T>(T item) where T : class, IEntity;
        void Create<T>(T item) where T : class, IEntity;
        void Delete<T>(T item) where T : class, IEntity;

        void UpdateMany<T>(IEnumerable<T> items) where T : class, IEntity;
        void CreateMany<T>(IEnumerable<T> items) where T : class, IEntity;
        void DeleteMany<T>(IEnumerable<T> items) where T : class, IEntity;

    }
}
