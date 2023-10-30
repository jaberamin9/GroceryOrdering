using GroceryOrdering.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryOrdering.Data
{
    public class GroceryOrderingDbContext : DbContext
    {
        public GroceryOrderingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImagesModelcs> ProductImages { get; set; }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }*/
    }
}
