using Microsoft.EntityFrameworkCore;
using Project.Core.Models;

namespace Project.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        
       
    }
}