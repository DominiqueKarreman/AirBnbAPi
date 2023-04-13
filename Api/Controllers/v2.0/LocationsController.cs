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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Model.DTO;

namespace Api.Controllers.v2._0
{
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
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

        /// <summary>
        /// Geeft alle locaties terug. Week 5
        /// </summary>
        /// <returns>Een lijst met alle locaties.</returns>
        /// <remarks>
        /// Deze functie haalt alle locaties op uit de database vanuit de service naar de repository.
        /// Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
        /// het response type is ActionResult LocationWithPriceDto. dus we verwachten een lijst van LocationWithPriceDto.
        /// gepaard met de status code van onze acties
        /// </remarks>
        /// <response code="200">Lijst met alle locaties.</response>
        /// <response code="400">Er is iets fout gegaan bij het ophalen van de locaties</response>
        [HttpGet]
        public async Task<ActionResult<LocationWithPriceDto>> GetLocations(
            CancellationToken cancellationToken
        )
        {
            try
            {
                return Ok(await _entityService.GetLocationsWithPrice(cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(
                    "Er ging wat fout bij het ophalen van de locaties: " + ex.Message
                );
            }
        }
    }
}
