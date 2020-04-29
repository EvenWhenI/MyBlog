using MyBlog.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.Entity.Entities
{
    [Table("PostContent")]
    public class PostContent: DomainEntity, IDateTracking
    {
        [Required]
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

    }
}
