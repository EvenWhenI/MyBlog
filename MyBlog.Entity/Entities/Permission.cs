using MyBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.Entity.Entities
{
    [Table("Permissions")]
    public class Permission : DomainEntity
    {
        [StringLength(450)]
        [Required]
        public Guid RoleId { get; set; }

        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }
    }
}
