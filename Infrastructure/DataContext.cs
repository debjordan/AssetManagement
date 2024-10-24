using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<CategoriaDefeito> CategoriasDefeito { get; set; }
    public DbSet<Defeito> Defeitos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipamento>().ToTable("Equipamentos");
        modelBuilder.Entity<CategoriaDefeito>().ToTable("CategoriasDefeito");
        modelBuilder.Entity<Defeito>().ToTable("Defeitos");
    }
}
