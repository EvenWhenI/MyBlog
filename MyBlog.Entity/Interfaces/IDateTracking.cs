using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entity.Interfaces
{
    public interface IDateTracking
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
