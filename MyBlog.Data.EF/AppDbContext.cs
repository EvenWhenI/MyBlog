using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Interfaces;
using System;
using System.Linq;

namespace MyBlog.Data.EF
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        #region DBset
        public DbSet<PostContent> PostContents { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity config
            // Custom table name of identiy

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId});

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId});

            #endregion

            //base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            //  Auto update property before save changes such as Datetime modify
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added).ToList();
            foreach (var item in modified)
            {
                var changedOrAddedItem = item as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreatedDate = DateTime.Now;
                    }

                    changedOrAddedItem.ModifiedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
