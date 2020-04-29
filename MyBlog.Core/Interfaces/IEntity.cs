using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
