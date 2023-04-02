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

namespace Api.Controllers
{
   [Route("api/[controller]")]
   /*[Route("api/v{version:apiVersion}/[controller]")]*/
   [ApiVersion("1.0")]
   [ApiController]
   public class LocationsController : ControllerBase
   {

      private readonly ApiContext _context;
      private readonly IEntityService _entityService;
      private readonly IMapper _mapper;

      public LocationsController(ApiContext context, IEntityService entityService, IMapper mapper)
      {
         _context = context;
         _entityService = entityService;
         _mapper = mapper;
      }



      // GET: api/Locations
      [HttpGet("GetAll")]
      public IEnumerable<LocationDto> GetLocation()
      {
         return _entityService.GetAllLocations().Select(location => _mapper.Map<LocationDto>(location));
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
      public async Task<ActionResult<Location>> GetLocations()
      {
        IEnumerable<LocationWithImageDto> locations = _entityService.GetLocationsWithImage();
         if (!locations.Any())
         {
            return BadRequest();

         }
         return Ok(locations);

      }

      // PUT: api/Locations/5
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPut("{id}")]
      public async Task<IActionResult> PutLocation(int id, Location location)
      {
         if (id != location.Id)
         {
            var tset = "";
            return BadRequest();
         }

         _context.Entry(location).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!LocationExists(id))
            {
               return NotFound();
            }
            else
            {
               throw;
            }
         }

         return NoContent();
      }

      // POST: api/Locations
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPost]
      public async Task<ActionResult<Location>> PostLocation(Location location)
      {
         if (_context.Location == null)
         {
            return Problem("Entity set 'ApiContext.Location'  is null.");
         }
         _context.Location.Add(location);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetLocation", new { id = location.Id }, location);
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
