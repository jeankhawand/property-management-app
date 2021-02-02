using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2.Filters;
using Assignment2.Helpers;
using Assignment2.Resources;
using Assignment2.Services;
using Assignment2.Validators;
using Assignment2.Wrappers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Models;
using Project.Core.Services;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public ApartmentController(IApartmentService apartmentService, IMapper mapper, IUriService uriService)
        {
            this._apartmentService = apartmentService;
            this._mapper = mapper;
            this._uriService = uriService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetAllApartments(decimal fromPrice, decimal toPrice, string address, int numberOfRooms)
        {
            var paginationFilter = new PaginationFilter();
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            IEnumerable<Apartment> apartments;
            if (fromPrice==0 && toPrice == 0 && address == null && numberOfRooms==0)
            {
                apartments = await _apartmentService.GetAllApartments();
            }
            else
            {
                 apartments = await _apartmentService.GetAllApartments(fromPrice,toPrice, address, numberOfRooms); 
            }
            var route = Request.Path.Value;
            var totalRecords = await _apartmentService.GetAllApartmentsCount();
            var apartmentResources = _mapper.Map<IEnumerable<Apartment>, IEnumerable<ApartmentResource>>(apartments);
            var pagedResponse = PaginationHelper.CreatePagedResponse<IEnumerable<ApartmentResource>>(apartmentResources, validFilter, totalRecords, _uriService, route);
            return Ok(pagedResponse);
            
            
        }
        [HttpPost("")]
        public async Task<ActionResult<ApartmentResource>> CreateApartment([FromBody] SaveApartmentResource saveApartmentResource)
        {
            var validator = new SaveApartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveApartmentResource);
        
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
        
            var apartmentToCreate = _mapper.Map<SaveApartmentResource, Apartment>(saveApartmentResource);
        
            var newApartment = await _apartmentService.CreatApartment(apartmentToCreate);
        
            var apartment = await _apartmentService.GetApartmentsById(newApartment.Id);
        
            var artistResource = _mapper.Map<Apartment, ApartmentResource>(apartment);
        
            return Ok(artistResource);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApartmentResource>> UpdateApartment(int id, [FromBody] SaveApartmentResource saveApartmentResource)
        {
            var validator = new SaveApartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveApartmentResource);
            
            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);
            
            var apartmentToBeUpdate = await _apartmentService.GetApartmentsById(id);

            if (apartmentToBeUpdate == null)
                return NotFound();

            var apartment = _mapper.Map<SaveApartmentResource, Apartment>(saveApartmentResource);

            await _apartmentService.UpdateApartment(apartmentToBeUpdate, apartment);

            var updatedApartment = await _apartmentService.GetApartmentsById(id);
            var updatedApartmentResource = _mapper.Map<Apartment, ApartmentResource>(updatedApartment);
    
            return Ok(updatedApartmentResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            if (id == 0)
                return BadRequest();
            
            var apartmentToBeDeleted = await _apartmentService.GetApartmentsById(id);

            if (apartmentToBeDeleted == null)
                return NotFound();

            await _apartmentService.DeleteApartment(apartmentToBeDeleted);

            return NoContent();
        }
        
    }
}