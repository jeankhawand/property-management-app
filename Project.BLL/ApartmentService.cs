using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Core;
using Project.Core.Models;
using Project.Core.Services;

namespace Project.BAL
{
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Apartment>> GetAllApartments(decimal fromPrice = 0, decimal toPrice = 0,
            string address = null, int numberOfRooms=0)
        {
            var apartments = _unitOfWork.Apartments.GetAllApartmentAsync();
            
            if (fromPrice != 0)
            {
                apartments = Task.FromResult(apartments.Result.Where(a => a.Price >= fromPrice));
            }
            if (toPrice != 0)
            {
                apartments = Task.FromResult(apartments.Result.Where(a => a.Price <= toPrice));
            }

            if (!String.IsNullOrEmpty(address))
            {
                apartments = Task.FromResult(apartments.Result.Where(s => s.Address.ToLower().Contains(address.ToLower())));
            }
            if (numberOfRooms != 0)
            {
                apartments = Task.FromResult(apartments.Result.Where(a => a.NbOfRooms == numberOfRooms));
            }
            apartments = Task.FromResult<IEnumerable<Apartment>>(apartments.Result.OrderByDescending(a => a.Price));
            
            return await apartments;
        }

        public async Task<Apartment> GetApartmentsById(int id)
        {
            return await _unitOfWork.Apartments.GetApartmentByIdAsync(id);
        }

        public async Task<Apartment> CreatApartment(Apartment newApartment)
        {
            
            await _unitOfWork.Apartments.AddAsync(newApartment);

            await _unitOfWork.CommitAsync();
            return newApartment;
        }

        public async Task UpdateApartment(Apartment apartmentToBeUpdated, Apartment apartment)
        {
            var result = await _unitOfWork.Apartments.GetApartmentByIdAsync(apartmentToBeUpdated.Id);
            if (result == null)
            {
                await CreatApartment(apartment);
            }
            else
            {
                
                  _unitOfWork.Apartments.UpdateApartmentAsync(apartmentToBeUpdated,apartment); 
            }
         
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteApartment(Apartment apartment)
        {
            _unitOfWork.Apartments.Remove(apartment);
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> GetAllApartmentsCount()
        {
            return await  _unitOfWork.Apartments.GetAllAppartmentCountAsync();
        }
    }
}