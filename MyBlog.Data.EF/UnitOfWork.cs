using MyBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Commit()
        {
            appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            appDbContext.Dispose();
        }
    }
}
