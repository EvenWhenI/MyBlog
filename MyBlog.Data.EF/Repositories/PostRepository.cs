using MyBlog.Core.Interfaces;
using MyBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Data.EF.Repositories
{
    class PostRepository : Repository<Post>
    {
        public PostRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }
    }
}
