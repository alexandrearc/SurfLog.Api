using Microsoft.EntityFrameworkCore;
using SurfLog.Api.Models;

public class SurfLogContext : DbContext {

    public SurfLogContext(DbContextOptions<SurfLogContext> options) : base(options){}

    public DbSet<Beach> Beaches { get; set; }
    
}