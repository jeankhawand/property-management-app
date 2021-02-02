using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.Core.Services
{
    public interface IBuyerService
    {
        /**
         * <summary>
         * Create Buyer
         * </summary>
         * <param name="newBuyer">new Buyer Instance</param>
         * <returns>
         * new Buyer Created
         * </returns>
         */
        Task<Buyer> CreateBuyer(Buyer newBuyer);
        /**
         * <summary>
         * Get Specific Buyer with owned Apartments
         * </summary>
         * <param name="id">Buyer Id</param>
         * <returns>
         * return buyer with credits and purchased apartments
         * </returns>
         */
        Task<Buyer> GetBuyerById(int id);

        /**
         * <summary>
         * Get apartments for a specific buyer.
         * </summary>
         * <param name="id">Buyer Id</param>
         * <returns>
         * return buyer with owned apartment 
         * </returns>
         */
        Task<IEnumerable<Property>> GetBuyerByIdWithApartment(int id);
        /**
         * <summary>
         * Allow a buyer to purchase an apartment by providing the buyer id and apartment id to the
           endpoint. It should return a result of whether the purchase was successful or not (based on the
           credit of the buyer vs. the price of the apartment). Ensure that once a purchase is successful, the
           buyer’s credit should be adjusted accordingly.
         * </summary>
         * <param name="buyerId">Buyer Id</param>
         * <param name="apartmentId">Apartment Id</param>
         * <returns>
         * return Purchase Success
         * </returns>
         */
        Task<Buyer> PurchaseAppartment(int buyerId, int apartmentId);
        /**
         * <summary>
         * Get all buyers with information about their credit and number of purchased apartments.
         * </summary>
         * <returns>
         * return buyer with credits and number of purchased apartments.
         * </returns>
         */
        Task<IEnumerable<Buyer>> GetAllBuyers();
    }
}