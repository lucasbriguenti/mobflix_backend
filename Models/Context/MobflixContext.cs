using Microsoft.EntityFrameworkCore;

namespace Mobflix_backend.Models.Context;

public class MobflixContext : DbContext
{
    public MobflixContext(DbContextOptions<MobflixContext> options) : base(options){ }
    
    public DbSet<Video> Videos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Video>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Video>()
            .HasOne(x => x.Categoria)
            .WithMany(x => x.Videos)
            .HasForeignKey(x => x.CategoriaId)
            .IsRequired();

        modelBuilder.Entity<Categoria>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Categoria>()
            .Property(x => x.Titulo)
            .IsRequired();
        
        modelBuilder.Entity<Categoria>()
            .Property(x => x.Color)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);
    }
}
