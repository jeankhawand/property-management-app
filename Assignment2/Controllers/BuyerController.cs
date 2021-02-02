using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Resources;
using Assignment2.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Models;
using Project.Core.Services;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        private readonly IMapper _mapper;
        public BuyerController(IBuyerService buyerService, IMapper mapper)
        {
            this._buyerService = buyerService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buyer>>> GetAllBuyers()
        {
            var buyers = await _buyerService.GetAllBuyers();
            var buyersResources = _mapper.Map<IEnumerable<Buyer>, IEnumerable<BuyerResource>>(buyers);
            return Ok(buyersResources);
            
            
        }
        [HttpGet("{id}/Apartments/")]
        public async Task<ActionResult<IEnumerable<Buyer>>> GetBuyerApartments(int id)
        {
            var buyerAppartments = await _buyerService.GetBuyerByIdWithApartment(id);
            if (!buyerAppartments.Any()) return NotFound();
            return Ok(buyerAppartments);
        }
        [HttpPost("")]
        public async Task<ActionResult<BuyerResource>> CreateBuyer([FromBody] SaveBuyerResource saveBuyerResource)
        {
            var validator = new SaveBuyerResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBuyerResource);
        
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
        
            var buyerToCreate = _mapper.Map<SaveBuyerResource, Buyer>(saveBuyerResource);
        
            var newBuyer = await _buyerService.CreateBuyer(buyerToCreate);
        
            var buyer = await _buyerService.GetBuyerById(newBuyer.Id);
        
            var buyerResource = _mapper.Map<Buyer, BuyerResource>(buyer);
        
            return Ok(buyerResource);
        }
        [HttpGet("{buyerId}/Apartment/{apartmentId}")]
        public async Task<ActionResult<ApartmentResource>> PurchaseApartment(int buyerId, int apartmentId)
        {
            var result = await _buyerService.PurchaseAppartment(buyerId, apartmentId);
            if (result == null) return NotFound();

            return Ok(result);
        }
        
        
    }
}