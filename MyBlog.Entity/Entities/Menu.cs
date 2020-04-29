using MyBlog.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.Entity.Entities
{
    [Table("Menus")]
    public class Menu : DomainEntity, IDateTracking
    {
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        public bool IsHotMenu { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<SubMenu> SubMenus { get; set; }
    }
}
