using MyBlog.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Entity.Entities
{
    [Table("Posts")]
    public class Post : DomainEntity, IDateTracking
    {
        [StringLength(450)]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid MenuId { get; set; }
        public Guid SubMenuId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual PostContent PostContent { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }


        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

        [ForeignKey("SubMenuId")]
        public virtual SubMenu SubMenu { get; set; }
    }
}
