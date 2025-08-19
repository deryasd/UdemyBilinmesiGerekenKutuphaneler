using Microsoft.EntityFrameworkCore;

namespace _1_FluentValidationApp.Web.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses{ get; set; }
    }
}
