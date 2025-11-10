using Microsoft.EntityFrameworkCore;
using Web_Shop.Models;


namespace ShopSbS.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Item> Items { get; set; }
   

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Web_Shop.Models.Basket> Basket { get; set; } = default!;
      

        // Add DbSet<TEntity> properties here, for example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
