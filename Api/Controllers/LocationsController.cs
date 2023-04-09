using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Model;
using Api.Services;
using AutoMapper;
using Api.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers
{
   [Route("api/[controller]")]
   [Route("api/v{version:apiVersion}/[controller]")]
   [ApiVersion("1.0")]
   [ApiController]
   public class LocationsController : ControllerBase
   {

      private readonly ApiContext _context;
      private readonly IEntityService _entityService;
      private readonly ISearchService _searchService;
      private readonly IMapper _mapper;

      public LocationsController(ApiContext context, IEntityService entityService, IMapper mapper, ISearchService searchService)
      {
         _context = context;
         _entityService = entityService;
         _mapper = mapper;
         _searchService = searchService;
      }



      // GET: api/Locations
      [HttpGet("GetAll")]
      public async Task<IEnumerable<LocationDto>> GetLocation(CancellationToken cancellationToken)
      {
         return await _entityService.GetAllLocations(cancellationToken);
      }

      // GET: api/Locations/5
      [HttpGet("{id}")]
      public async Task<ActionResult<Location>> GetLocation(int id)
      {
         if (_context.Location == null)
         {
            return NotFound();
         }
         var location = await _context.Location.FindAsync(id);

         if (location == null)
         {
            return NotFound();
         }

         return location;
      }

      [HttpGet]
      public async Task<IEnumerable<LocationWithImageDto>> GetLocations(CancellationToken cancellationToken)
      {
         var locations = await _entityService.GetLocationsWithImage(cancellationToken);
         if (!locations.Any())
         {
            return new List<LocationWithImageDto>();
         }
         return locations;

      }
      // POST: api/Locations
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPost("Search")]
      public async Task<IEnumerable<LocationWithPriceDto>> PostLocation([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] SearchDto search, CancellationToken cancellationToken)
      {
         var locations = await _searchService.Search(cancellationToken, search);
         return locations;
        
      }

      // DELETE: api/Locations/5
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteLocation(int id)
      {
         if (_context.Location == null)
         {
            return NotFound();
         }
         var location = await _context.Location.FindAsync(id);
         if (location == null)
         {
            return NotFound();
         }

         _context.Location.Remove(location);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool LocationExists(int id)
      {
         return (_context.Location?.Any(e => e.Id == id)).GetValueOrDefault();
      }
   }
}
