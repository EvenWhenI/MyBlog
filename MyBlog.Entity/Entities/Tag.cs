using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.Entity.Entities
{
    [Table("Tags")]
    public class Tag: DomainEntity
    {
        public string Name { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
