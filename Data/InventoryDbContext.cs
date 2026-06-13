using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryItem>().HasData(
                new InventoryItem { Id = 1, ProductId = 1, Quantidade = 20 },
                new InventoryItem { Id = 2, ProductId = 2, Quantidade = 15 },
                new InventoryItem { Id = 3, ProductId = 3, Quantidade = 50 },
                new InventoryItem { Id = 4, ProductId = 4, Quantidade = 30 }
            );
        }
    }
}