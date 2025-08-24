using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Persistence
{
    public class AssetManagementDbContext : DbContext
    {
        public AssetManagementDbContext(DbContextOptions<AssetManagementDbContext> options)
            : base(options) { }

        public DbSet<Equipment> Equipments { get; set; }
    }
}
