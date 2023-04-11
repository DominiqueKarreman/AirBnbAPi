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
    [ApiController]
    public class ReservationsController : ControllerBase
    {

      private readonly ApiContext _context;
      private readonly IEntityService _entityService;
      private readonly ISearchService _searchService;
      private readonly IMapper _mapper;

      public ReservationsController(ApiContext context, IEntityService entityService, IMapper mapper, ISearchService searchService)
      {
         _context = context;
         _entityService = entityService;
         _mapper = mapper;
         _searchService = searchService;
      }

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationResponseDto>> PostReservation(ReservationRequestDto request, CancellationToken cancellationToken)
        {
         try
         {
            ReservationResponseDto response = await _entityService.StoreReservation(cancellationToken, request);
            return Ok(response);

         }
         catch (InvalidOperationException ex)
         {
            return Conflict("Er ging wat fout bij het aanmaken van je reservatie: " + ex.Message);
         }
         catch (Exception ex)
         {
            return BadRequest("Er ging wat fout bij het aanmaken van je reservatie: " + ex.Message);
         }
        }

        private bool ReservationExists(int id)
        {
            return (_context.Reservation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
