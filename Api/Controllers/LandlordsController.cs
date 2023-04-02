using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Model;
using Api.Model.DTO;
using Api.Services;
using Api.Service;
using AutoMapper;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IEntityService _entityService;
      private readonly IMapper _mapper;

      public LandlordsController(ApiContext context, IEntityService entityService, IMapper mapper)
        {
            _context = context;
         _entityService = entityService;
         _mapper = mapper;
      }


        // GET: api/Landlords
        [HttpGet("GetAll")]
        public IEnumerable<LandlordDto> GetLandlord()
        {
         return _entityService.GetAllLandlords().Select(landlord => _mapper.Map<LandlordDto>(landlord));
      }

        // GET: api/Landlords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Landlord>> GetLandlord(int id)
        {
            var landlord = await _context.Landlord.FindAsync(id);

            if (landlord == null)
            {
                return NotFound();
            }

            return landlord;
        }

        // PUT: api/Landlords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLandlord(int id, Landlord landlord)
        {
            if (id != landlord.Id)
            {
                return BadRequest();
            }

            _context.Entry(landlord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandlordExists(id))
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

        // POST: api/Landlords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Landlord>> PostLandlord(Landlord landlord)
        {
            _context.Landlord.Add(landlord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLandlord", new { id = landlord.Id }, landlord);
        }

        // DELETE: api/Landlords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLandlord(int id)
        {
            var landlord = await _context.Landlord.FindAsync(id);
            if (landlord == null)
            {
                return NotFound();
            }

            _context.Landlord.Remove(landlord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LandlordExists(int id)
        {
            return _context.Landlord.Any(e => e.Id == id);
        }
    }
}
