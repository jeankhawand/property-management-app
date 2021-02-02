using Microsoft.EntityFrameworkCore;
using Project.Core.Models;

namespace Project.DAL
{
    public class ConsoleDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=localhost,1433;Initial Catalog=PropertyDB;Integrated Security=False;User Id=sa; Password=yourStrong(!)Password");
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Shop> Shops { get; set; }
        
        public DbSet<Property> Properties { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
    }
}