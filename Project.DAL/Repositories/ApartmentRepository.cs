using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Core.Models;
using Project.Core.Repositories;

namespace Project.DAL.Repositories
{
    public class ApartmentRepository: Repository<Apartment>, IApartmentRepository
    {
        private AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
        public ApartmentRepository(AppDbContext context) 
            : base(context)
        { }

        public async Task<IEnumerable<Apartment>> GetAllApartmentAsync()
        {
            // if (PageNumber != 0 && PageSize != 0)
            // {
            //     return await AppDbContext.Apartments.Skip((PageNumber - 1) * PageSize)
            //         .Take(PageSize).ToListAsync();
            //   
            // }
            // else
            // {
                return await AppDbContext.Apartments.ToListAsync();
                
            // }
        }

        public async Task<int> GetAllAppartmentCountAsync()
        {
            return await AppDbContext.Apartments.CountAsync();
        }
        
        public void UpdateApartmentAsync(Apartment apartmentToBeUpdated , Apartment apartment)
        {
            apartmentToBeUpdated.NbOfRooms = apartment.NbOfRooms;
            apartmentToBeUpdated.Title = apartment.Title;
            apartmentToBeUpdated.Address = apartment.Address;
            AppDbContext.Apartments.Update(apartmentToBeUpdated);
        }

        public async Task<Apartment> GetApartmentByIdAsync(int id)
        {
            return await AppDbContext.Apartments.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}