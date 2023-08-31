using Microsoft.EntityFrameworkCore;
using Web_ShopRozkov.Models;

namespace Web_ShopRozkov.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
