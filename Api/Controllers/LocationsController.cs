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
    [ApiVersion("1.0")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IEntityService _entityService;
        private readonly ISearchService _searchService;

        public LocationsController(
            ApiContext context,
            IEntityService entityService,
            IMapper mapper,
            ISearchService searchService
        )
        {
            _context = context;
            _entityService = entityService;
            _searchService = searchService;
        }

        /// <summary>
        /// Geeft alle locaties terug met fotos. Week 4
        /// </summary>
        /// <returns>Een lijst met alle locaties.</returns>
        /// <remarks>
        /// Deze functie haalt alle locaties op uit de database vanuit de service naar de repository.
        /// Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
        /// het response type is ActionResult LocationWithImageDto. dus we verwachten een lijst van LocationWithImageDto.
        /// gepaard met de status code van onze acties
        /// </remarks>
        /// <response code="200">Lijst met alle locaties.</response>
        /// <response code="400">Er is iets fout gegaan bij het ophalen van de locaties</response>
        [HttpGet]
        public async Task<ActionResult<LocationWithImageDto>> GetLocationsWithImages(
            CancellationToken cancellationToken
        )
        {
            //Deze functie haalt alle locaties op uit de database vanuit de Service.
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is ActionResult LocationWithImageDto. dus we verwachten een lijst van locaties.
            //gepaard met een status code van onze acties
            try
            {
                //Als alles goed gaat krijgen wij een status 200 met de locaties
                return Ok(await _entityService.GetLocationsWithImage(cancellationToken));
            }
            catch (Exception ex)
            {
                //Als er iets fout gaat krijgen wij een badrequest terug gestuurd met de bij behorende error
                return BadRequest(
                    "Er ging wat fout bij het ophalen van de locaties: " + ex.Message
                );
            }
        }

        /// <summary>
        /// Geeft alle locaties terug. Week 3
        /// </summary>
        /// <returns>Een lijst met alle locaties.</returns>
        /// <remarks>
        /// Deze functie haalt alle locaties op uit de database vanuit de service naar de repository.
        /// Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
        /// het response type is ActionResult Location. dus we verwachten een lijst van locaties.
        /// gepaard met de status code van onze acties
        /// </remarks>
        /// <response code="200">Lijst met alle locaties.</response>
        /// <response code="400">Er is iets fout gegaan bij het ophalen van de locaties</response>
        // GET: api/Locations
        [HttpGet("GetAll")]
        public async Task<ActionResult<Location>> GetLocation(CancellationToken cancellationToken)
        {
            try
            {
                //Als alles goed gaat krijgen wij een status 200 met de locaties
                return Ok(await _entityService.GetAllLocations(cancellationToken));
            }
            catch (Exception ex)
            {
                //Als er iets fout gaat krijgen wij een status 400 terug gestuurd met de bij behorende error
                return BadRequest(
                    "Er ging wat fout bij het ophalen van de locaties: " + ex.Message
                );
            }
        }

        /// <summary>
        /// Geeft de Hoogste prijs van alle locaties terug uit de database als een PriceDto. Week 6
        /// </summary>
        /// <returns>Een lijst met alle locaties.</returns>
        /// <remarks>
        /// Deze functie haalt de hoogste prijs van de locaties op en stuurt het terug als een response van het type
        /// PriceDto gepaard met de status code van onze acties
        /// </remarks>
        /// <response code="200">Hoogste prijs van de locaties</response>
        /// <response code="400">Er is iets fout gegaan bij het ophalen van de hoogste prijs</response>
        [HttpGet("GetMaxPrice")]
        public async Task<ActionResult<PriceDto>> GetMaxPrice(CancellationToken cancellationToken)
        {
            try
            {
                //als alles goed gaat krijgen we een status 200 met de hoogste prijs.
                return Ok(await _entityService.GetMaxPrice(cancellationToken));
            }
            catch (Exception ex)
            {
                //Als er iets fout gaat krijgen wij een status 400 terug gestuurd met de bij behorende error
                return BadRequest(
                    "Er is iets fout gegaan bij het ophalen van de hoogste prijs: " + ex.Message
                );
            }
        }

      /// <summary>
      /// Geeft alle informatie over een locatie met de id:{id}. Week 6
      /// </summary>
      /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
      /// <param name="id">Id van de locatie</param>
      /// <returns>returned een locatie met alle informatie</returns>
      /// <remarks>
      /// Deze functie returned een locatie met alle informatie om te kunnen boeken.
      /// Het response type van de functie is ActionResult DetailDto dus we verwachten een detaildto
      /// gepaard met de juiste status code
      /// </remarks>
      /// <response code="200">Details van locatie: {id}</response>
      /// <response code="400">Er is iets fout gegaan bij het ophalen van de details van locatie: {id} prijs</response>
      /// <response code="404">Kon de locatie: {id} niet vinden in de database</response>
      [HttpGet("GetDetails/{id}")]
        public async Task<ActionResult<DetailDto>> GetDetails(
            CancellationToken cancellationToken,
            int id
        )
        {
            try
            {
                //als alles goed gaat krijgen we een status 200 met de details van locatie met id: {id}.
                return Ok(await _entityService.GetDetails(cancellationToken, id));
            }
            catch (KeyNotFoundException ex)
            {
            //Als de id niet gevonden kon worden in de database krijg je een error met de bijbehorende statuscode
            return NotFound(
                    "Er is iets fout gegaan bij het ophalen van de details van locatie "
                        + id
                        + ": "
                        + ex.Message
                );
            }
            catch (Exception ex)
            {
                //Als er iets fout gaat krijgen wij een status 400 terug gestuurd met de bij behorende error
                return BadRequest(
                    "Er is iets fout gegaan bij het ophalen van de details van locatie "
                        + id
                        + ": "
                        + ex.Message
                );
            }
        }

      /// <summary>
      /// Haalt unavailable dates op van locatie met id:{id}. Week 7
      /// </summary>
      /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
      /// <param name="id">Id van de locatie</param>
      /// <returns>returned een UnavailableDatesDto met de unavailable datums</returns>
      /// <remarks>
      /// Deze functie returned een UnavailableDatesDto waarin de datums die niet beschikbaar zijn gereturned worden
      /// Het response type van de functie is UnavailableDatesDto  dus we verwachten een UnavailableDatesDto
      /// gepaard met de juiste status code
      /// </remarks>
      /// <response code="200">Unavailable dates van locatie: {id}</response>
      /// <response code="400">Er is iets fout gegaan bij het ophalen van de Unavailable dates van locatie: {id} prijs</response>
      /// <response code="404">Kon de locatie: {id} niet vinden in de database</response>
      [HttpGet("UnAvailableDates/{id}")]
        public async Task<ActionResult<UnAvailableDatesDto>> UnAvailableDates(
            CancellationToken cancellationToken,
            int id
        )
        {
            try
            {
                return Ok(await _entityService.UnAvailableDates(cancellationToken, id));
            }
            catch (KeyNotFoundException ex)
            {
            //Als de id niet gevonden kon worden in de database krijg je een error met de bijbehorende statuscode
            return NotFound(
                    "Er is iets fout gegaan bij het ophalen van de UnAvailableDates de van locatie "
                        + id
                        + ": "
                        + ex.Message
                );
            }
            catch (Exception ex)
            {
                //Als er iets fout gaat krijgen wij een status 400 terug gestuurd met de bij behorende error
                return BadRequest(
                    "Er is iets fout gegaan bij het ophalen van de UnAvailableDates de van locatie "
                        + id
                        + ": "
                        + ex.Message
                );
            }
        }

      /// <summary>
      /// Haalt locaties op door middel van filters. Week 6
      /// </summary>
      /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
      /// <returns>returned een lijst met locaties gefiltered met de search method</returns>
      /// <remarks>
      /// Deze functie returned een Locatie die gefiltered is met de search method
      /// Het response type van de functie is ActionResult LocationWithPriceDto dus we verwachten een LocationWithPriceDto
      /// gepaard met de juiste status code
      /// </remarks>
      /// <response code="200">Lijst met Locaties</response>
      /// <response code="400">Er is iets fout gegaan bij het ophalen van de Locaties: {id} prijs</response>
      [HttpPost("Search")]
        public async Task<ActionResult<LocationWithPriceDto>> PostLocation(
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] SearchDto search,
            CancellationToken cancellationToken
        )
        {
         try
         {
            return Ok(await _searchService.Search(cancellationToken, search));
         }
         catch(Exception ex)
         {
            return BadRequest(
                    "Er is iets fout gegaan bij het ophalen van de locaties: "
                        + ex.Message
                );
         }
            
        }
    }
}
