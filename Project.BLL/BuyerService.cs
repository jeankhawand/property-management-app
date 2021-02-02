using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Core;
using Project.Core.Models;
using Project.Core.Services;

namespace Project.BAL
{
    public class BuyerService : IBuyerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuyerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Buyer> CreateBuyer(Buyer newBuyer)
        {

            
                await _unitOfWork.Buyers.AddAsync(newBuyer);
                await _unitOfWork.CommitAsync();
                return newBuyer;

        }

        public async Task<Buyer> GetBuyerById(int id)
        {
            return await _unitOfWork.Buyers.GetBuyerByIdAsync(id);
        }

        public async Task<IEnumerable<Property>> GetBuyerByIdWithApartment(int id)
        {
            var buyer = await _unitOfWork.Buyers.GetBuyerByIdAsync(id);
            var buyerApartments = from properties in buyer.Properties
                where properties.GetType() == typeof(Apartment)
                select properties;
            return buyerApartments;
        }

        public async Task<Buyer> PurchaseAppartment(int buyerId, int apartmentId)
        {
            var propertyPurchased = await _unitOfWork.Buyers.GetAllBuyersAsync();
            List<Apartment> ownedApartments = new List<Apartment>();
            foreach (var b in propertyPurchased)
            {
                foreach (var bProperty in b.Properties.OfType<Apartment>())
                {
                    ownedApartments.Add(bProperty);
                }
            }
            var apartmentToBePurchased = await _unitOfWork.Apartments.GetApartmentByIdAsync(apartmentId);
            var buyer = await _unitOfWork.Buyers.GetBuyerByIdAsync(buyerId);
            if (apartmentToBePurchased == null || buyer == null)
            {
                return null;
            }

            if (ownedApartments.Contains(apartmentToBePurchased))
            {
                return null;
            }

            if (!ownedApartments.Contains(apartmentToBePurchased))
            {
                if (buyer.Credits > apartmentToBePurchased.Price)
                {
                    var remainingCredits = buyer.Credits - apartmentToBePurchased.Price;
                    if (remainingCredits < 0)
                    {
                        return null;
                    }

                    buyer.Credits = remainingCredits;
                    buyer.Properties.Add(apartmentToBePurchased);
                    await _unitOfWork.CommitAsync();
                    return buyer;
                }
            }

            return null;
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyers()
        {
            return await _unitOfWork.Buyers.GetAllBuyersAsync();
        }
    }
}