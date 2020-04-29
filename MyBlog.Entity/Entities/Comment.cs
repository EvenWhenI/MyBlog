using MyBlog.Entity.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Entity.Entities
{
    [Table("Comments")]
    public class Comment : DomainEntity, IDateTracking
    {
        [StringLength(450)]
        [Required]
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

    }
}
