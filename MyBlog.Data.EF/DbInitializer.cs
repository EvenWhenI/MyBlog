using Microsoft.AspNetCore.Identity;
using MyBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _appDbContext;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public DbInitializer(AppDbContext appDbContext, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole() { 
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top Manager"
                });
            }

            if (!_userManager.Users.Any())
            {
                var result = await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Adminstrator",
                    Email = "holycsm@gmail.com",
                },"Luutt@12345");

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync("admin");
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
