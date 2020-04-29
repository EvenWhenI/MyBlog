using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Entity.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime? DateOfBird { get; set; }
        public string Avatar { get; set; }
    }
}
