using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.Core.Repositories
{
    public interface IBuyerRespository:IRepository<Buyer>
    {
        Task<IEnumerable<Buyer>> GetAllBuyersAsync();
        Task<Buyer> GetBuyerByIdAsync(int id);
    }
}