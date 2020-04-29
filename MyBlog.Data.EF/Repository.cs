using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Interfaces;
using MyBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Data.EF
{
    public class Repository<T> : IRepository<T>, IDisposable where T : DomainEntity
    {
        private readonly AppDbContext appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(T entity)
        {
            appDbContext.Add(entity);
        }

        public void Dispose()
        {
            if (appDbContext != null) appDbContext.Dispose();
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = appDbContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    items = items.Include(property);
                }
            }

            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = appDbContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    items = items.Include(property);
                }
            }

            return items.Where(predicate);
        }

        public T FindByID(string id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public T FindBySingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            appDbContext.Set<T>().Remove(entity);
        }

        public void Remove(string id)
        {
            appDbContext.Set<T>().Remove(FindByID(id));
        }

        public void RemoveMultiple(List<T> lstEntity)
        {
            appDbContext.Set<T>().RemoveRange(lstEntity);
        }

        public void Update(T entity)
        {
            appDbContext.Set<T>().Update(entity);
        }
    }
}
