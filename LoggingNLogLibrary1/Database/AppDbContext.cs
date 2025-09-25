using LoggingNLogLibrary1.Models;
using Microsoft.EntityFrameworkCore;

namespace LoggingNLogLibrary1.Database
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FDKFGC2;Initial Catalog=NlogDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Log> Logs{ get; set; }
    }
}
