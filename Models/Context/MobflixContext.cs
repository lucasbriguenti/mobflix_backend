using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;

namespace Mobflix_backend.Models.Context;

public class MobflixContext : DbContext
{
    public MobflixContext(DbContextOptions<MobflixContext> options) : base(options){ }
    
    public DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Video>()
            .HasKey(x => x.Id);
        
        base.OnModelCreating(modelBuilder);
    }
}
