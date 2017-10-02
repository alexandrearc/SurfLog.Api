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

        public void Initialize(){

            AdminInitialize();

            BeachInitialize();
        }
        public async void AdminInitialize(){

            _context.Database.EnsureCreated();

            if(_context.Roles.Any(r => r.Name == "Administrator")) return;

            await _roleManager.CreateAsync(new Role("Administrator"));

            string user = "admin";
            string email = "admin@surflog";
            string password = "P@ssword1";
            await _userManager.CreateAsync(new User { UserName = user, Email = email, EmailConfirmed = true}, password);
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), "Administrator");
        }

        public void BeachInitialize(){

            _context.Database.EnsureCreated();

            if(_context.Beaches.Any()) return;
            
            _context.Beaches.Add(new Beach { Name="90 Mile Beach"});
            _context.Beaches.Add( new Beach { Name="Ahipara Beach"});
            _context.Beaches.Add( new Beach { Name="Aranga Beach"});
            _context.Beaches.Add( new Beach { Name="Baylys Beach"});
            _context.Beaches.Add( new Beach { Name="Bland Bay"});
            _context.Beaches.Add( new Beach { Name="Bluehouse"});
            _context.Beaches.Add( new Beach { Name="Elliot Bay"});
            _context.Beaches.Add( new Beach { Name="Glinks Gully"});
            _context.Beaches.Add( new Beach { Name="Helena Bay"});
            _context.Beaches.Add( new Beach { Name="Henderson Bay"});
            _context.Beaches.Add( new Beach { Name="Hokianga"});
            _context.Beaches.Add( new Beach { Name="Houhora Heads"});
            _context.Beaches.Add( new Beach { Name="Kawerua Reefs"});
            _context.Beaches.Add( new Beach { Name="Langs Beach - Ding Bay"});
            _context.Beaches.Add( new Beach { Name="Matauri Bay"});
            _context.Beaches.Add( new Beach { Name="Mimiwhangata Bay"});
            _context.Beaches.Add( new Beach { Name="Motukahakaha Bay"});
            _context.Beaches.Add( new Beach { Name="Moureeses Bay"});
            _context.Beaches.Add( new Beach { Name="Mukie 1"});
            _context.Beaches.Add( new Beach { Name="Mukie 2"});
            _context.Beaches.Add( new Beach { Name="Ngunguru Bar"});
            _context.Beaches.Add( new Beach { Name="Oakura Bay"});
            _context.Beaches.Add( new Beach { Name="Ocean Beach"});
            _context.Beaches.Add( new Beach { Name="Okupe Beach"});
            _context.Beaches.Add( new Beach { Name="Pataua"});
            _context.Beaches.Add( new Beach { Name="Pataua Bar"});
            _context.Beaches.Add( new Beach { Name="Pines"});
            _context.Beaches.Add( new Beach { Name="Pouto"});
            _context.Beaches.Add( new Beach { Name="Puwheke Beach"});
            _context.Beaches.Add( new Beach { Name="Rarawa Beach"});
            _context.Beaches.Add( new Beach { Name="Raupo Bay"});
            _context.Beaches.Add( new Beach { Name="Ripiro Beach"});
            _context.Beaches.Add( new Beach { Name="Russell - Oneroa Bay"});
            _context.Beaches.Add( new Beach { Name="Sandy Bay"});
            _context.Beaches.Add( new Beach { Name="Scotts Point"});
            _context.Beaches.Add( new Beach { Name="Shipwreck Bay"});
            _context.Beaches.Add( new Beach { Name="Spirits Bay"});
            _context.Beaches.Add( new Beach { Name="Supertubes"});
            _context.Beaches.Add( new Beach { Name="Taipa"});
            _context.Beaches.Add( new Beach { Name="Takou Bay"});
            _context.Beaches.Add( new Beach { Name="Tanutanu"});
            _context.Beaches.Add( new Beach { Name="Tapotupotu Bay"});
            _context.Beaches.Add( new Beach { Name="Taupo Bay"});
            _context.Beaches.Add( new Beach { Name="Te Paki"});
            _context.Beaches.Add( new Beach { Name="Te Werahi Beach"});
            _context.Beaches.Add( new Beach { Name="The Bluff"});
            _context.Beaches.Add( new Beach { Name="The Box"});
            _context.Beaches.Add( new Beach { Name="Tokerau Beach"});
            _context.Beaches.Add( new Beach { Name="Tom Bowling Bay"});
            _context.Beaches.Add( new Beach { Name="Twilight Beach"});
            _context.Beaches.Add( new Beach { Name="Waimamaku"});
            _context.Beaches.Add( new Beach { Name="Wainui Bay - Northland"});
            _context.Beaches.Add( new Beach { Name="Waipoua Reefs"});
            _context.Beaches.Add( new Beach { Name="Waipu Bar"});
            _context.Beaches.Add( new Beach { Name="Waipu Cove"});
            _context.Beaches.Add( new Beach { Name="Whananaki"});
            _context.Beaches.Add( new Beach { Name="Woolleys Bay"});
            
            _context.SaveChanges();
        }
    }
}