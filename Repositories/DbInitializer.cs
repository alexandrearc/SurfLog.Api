using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SurfLog.Api.Models;

namespace SurfLog.Api.Repositories
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SurfLogContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DbInitializer(SurfLogContext surfLogContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = surfLogContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize(){

            _context.Database.EnsureCreated();

            if(_context.Roles.Any(r => r.Name == "Administrator")) return;

            await _roleManager.CreateAsync(new Role("Administrator"));

            string user = "admin@surf.com";
            string password = "P@ssword1";
            await _userManager.CreateAsync(new User { UserName = user, Email = user, EmailConfirmed = true}, password);
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), "Administrator");
        }
    }
}