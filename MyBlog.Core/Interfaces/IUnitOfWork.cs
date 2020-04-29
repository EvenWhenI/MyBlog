using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
