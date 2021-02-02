using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.Core.Services
{
    public interface IApartmentService
    {
        /**
         * <summary>
         * Get apartments filtered by (price range from / to, address [containing provided text – case
            insensitive], number of rooms) sorted by price descending. In case, no filter values were
            provided, then all apartments should be returned. In case, 1 or many filter values were
            provided, then only the apartments which meet all the provided criteria should be returned.
         * </summary>
         * <param name="fromPrice">Search By Starting Price</param>
         * <param name="toPrice">Search by Ending Price</param>
         * <param name="address">Search by Address</param>
         * <param name="numberOfRooms">Search by Number Of Rooms</param>
         * <returns>
         * Get apartments filtered by (price range from / to, address [containing provided text – case
            insensitive], number of rooms) sorted by price descending
         * </returns>
         */
        Task<IEnumerable<Apartment>> GetAllApartments(decimal fromPrice=0, decimal toPrice=0, string address=null, int numberOfRooms = 0);
        /**
         * <summary>
         * get specific apartment
         * </summary>
         * <param name="id">Apartment Id</param>
         * <returns>
         * specific apartment
         * </returns>
         */
        Task<Apartment> GetApartmentsById(int id);
        /**
         * <summary>
         * get specific apartment
         * </summary>
         * <param name="newApartment">Apartment Id</param>
         * <returns>
         * specific apartment
         * </returns>
         */
        Task<Apartment> CreatApartment(Apartment newApartment);
        Task UpdateApartment(Apartment apartmentToBeUpdated, Apartment apartment);
        Task DeleteApartment(Apartment apartment);
        Task<int> GetAllApartmentsCount();
    }
}