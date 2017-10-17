using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurfLog.Api.Models;

public class SurfLogContext : IdentityDbContext<User, Role, string> 
{
    
    public DbSet<Beach> Beaches { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User> User { get; set; } 
    public DbSet<Condition> Conditions { get; set; }

    public SurfLogContext(DbContextOptions<SurfLogContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Session>()
            .HasOne( s => s.Condition)
            .WithOne( c => c.Session )
            .HasForeignKey<Condition>( s => s.SessionId);
    }
}