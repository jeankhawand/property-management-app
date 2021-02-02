using System.Linq;
using AutoMapper;
using Project.Core.Models;

namespace Assignment2.Resources
{
    public class MappingProfile : Profile {
        public MappingProfile() {
            // Add as many of these lines as you need to map your objects
            CreateMap<Apartment, ApartmentResource>();
            CreateMap<SaveApartmentResource, Apartment>();
            // mapping properties array to number of purchased apartments
            CreateMap<Buyer, BuyerResource>().ForMember(dest=>dest.NbOfApartments,
                act=>act.MapFrom(src=>src.Properties.OfType<Apartment>().Count()));
            CreateMap<SaveBuyerResource, Buyer>();
        }
    }
}