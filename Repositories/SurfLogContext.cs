using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurfLog.Api.Models;

public class SurfLogContext : IdentityDbContext<User, Role, string> 
{
    public SurfLogContext(DbContextOptions<SurfLogContext> options) : base(options){}
    public DbSet<Beach> Beaches { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User> User { get; set; } 
    public DbSet<Condition> Conditions {get; set;}
}