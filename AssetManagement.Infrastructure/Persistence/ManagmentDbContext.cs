using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Persistence
{
    public class AssetManagementDbContext : DbContext
    {
        public AssetManagementDbContext(DbContextOptions<AssetManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Active");

                entity.Property(e => e.PurchaseDate)
                    .IsRequired();

                // OV
                entity.OwnsOne(e => e.SerialNumber, sn =>
                {
                    sn.Property(s => s.Value)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("SerialNumber");

                    sn.HasIndex(s => s.Value)
                        .IsUnique()
                        .HasDatabaseName("IX_Equipment_SerialNumber");
                });

                entity.ToTable("Equipments");
            });
        }
    }
}
