using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.Core.Repositories
{
    public interface IApartmentRepository:IRepository<Apartment>
    {
        Task<IEnumerable<Apartment>> GetAllApartmentAsync();
        Task<Apartment> GetApartmentByIdAsync(int id);
        void UpdateApartmentAsync(Apartment apartmentToBeUpdated,Apartment apartment);
        Task<int> GetAllAppartmentCountAsync();
    }
}