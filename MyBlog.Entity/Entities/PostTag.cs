using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.Entity.Entities
{
    [Table("PostTags")]
    public class PostTag : DomainEntity
    {
        public Guid PostId { get; set; }
        
        public Guid TagId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
