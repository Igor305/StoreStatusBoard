using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Device> Devices { get; }
        public DbSet<Monitoring> Monitorings { get; }
        public DbSet<Stock> Stock { get; }
        public DbSet<Stocks> Stocks { get; }

    }
}
