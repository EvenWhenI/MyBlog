using MyBlog.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.Entity.Entities
{
    [Table("SubMenus")]
    public class SubMenu : DomainEntity, IDateTracking
    {
        [StringLength(25)]
        public string Name { get; set; }
        
        public bool IsHotMenu { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        public Guid ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Menu Menu { get; set; }
    }
}
