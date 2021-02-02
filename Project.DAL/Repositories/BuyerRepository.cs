using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Core.Models;
using Project.Core.Repositories;

namespace Project.DAL.Repositories
{
    public class BuyerRepository: Repository<Buyer>, IBuyerRespository
    {
        private AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
        public BuyerRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyersAsync()
        {
            return await AppDbContext.Buyers.Include(b=>b.Properties).ToListAsync();
        }

        public async Task<Buyer> GetBuyerByIdAsync(int id)
        {
            return await AppDbContext.Buyers.Include(b => b.Properties).FirstOrDefaultAsync(b=>b.Id == id);
        }
        
    }
}