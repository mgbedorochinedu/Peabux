using Microsoft.EntityFrameworkCore;
using Peabux.API.Entities;

namespace Peabux.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }

    }
}
