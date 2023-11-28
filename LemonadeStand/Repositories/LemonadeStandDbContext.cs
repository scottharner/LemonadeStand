using LemonadeStand.Models;
using Microsoft.EntityFrameworkCore;

namespace LemonadeStand.Repositories
{
    public class LemonadeStandDbContext : DbContext
    {
        public LemonadeStandDbContext(DbContextOptions<LemonadeStandDbContext> options) : base(options) 
        { 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
