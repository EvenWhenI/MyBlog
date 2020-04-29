using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T FindByID(string id, params Expression<Func<T, object>>[] includeProperties);
        T FindBySingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);
        void Update(T entity);
        void Remove(string id);
        void Remove(T entity);
        void RemoveMultiple(List<T> lstEntity);
    }
}
