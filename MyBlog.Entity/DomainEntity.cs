using MyBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entity
{
    public class DomainEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
