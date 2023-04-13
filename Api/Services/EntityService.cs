using Api.Model;
using Api.Model.DTO;
using Api.Repositories;
using AutoMapper;
using NuGet.Configuration;
using System.Linq;

namespace Api.Services
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IMapper _mapper;

        public EntityService(IEntityRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Location>> GetAllLocations(
            CancellationToken cancellationToken
        )
        {
            //Deze functie haalt alle locaties op uit de database vanuit de repository.
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is IEnumerable Location. dus we verwachten een lijst van locaties.

            return await _entityRepository.GetAllLocations(cancellationToken);
        }

        public async Task<IEnumerable<LocationWithImageDto>> GetLocationsWithImage(
            CancellationToken cancellationToken
        )
        {
            //Deze functie haalt alle locaties op uit de database vanuit de repository.
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is IEnumerable LocationWithImageDto. dus we verwachten een lijst van LocationWithImageDto.

            return _mapper.Map<IEnumerable<LocationWithImageDto>>(
                await _entityRepository.GetAllLocationsV2(cancellationToken)
            );
        }

        public async Task<PriceDto> GetMaxPrice(CancellationToken cancellationToken)
        {
            //Deze functie haalt de hoogste prijs van de locaties op en stuurt het terug als een response van het type
            //PriceDto gepaard met de status code van onze acties

            return _mapper.Map<PriceDto>(await _entityRepository.GetMaxPrice(cancellationToken));
        }

        public async Task<IEnumerable<LocationWithPriceDto>> GetLocationsWithPrice(
            CancellationToken cancellationToken
        )
        {
            //Deze functie haalt alle locaties op uit de database vanuit de repository.
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is IEnumerable LocationWithPriceDto. dus we verwachten een lijst van LocationWithPriceDto.

            return _mapper.Map<IEnumerable<LocationWithPriceDto>>(
                await _entityRepository.GetAllLocationsV2(cancellationToken)
            );
        }

        public async Task<DetailDto> GetDetails(CancellationToken cancellationToken, int Id)
        {
            //Deze functie haalt de details van locatie met id: {id} op uit de database vanuit de repository.
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is DetailDto. dus we verwachten een DetailDto.
            return _mapper.Map<DetailDto>(await _entityRepository.GetDetails(cancellationToken, Id))
                ?? throw new KeyNotFoundException("Kon locatie " + Id + " niet vinden");
        }

        public async Task<UnAvailableDatesDto> UnAvailableDates(
            CancellationToken cancellationToken,
            int Id
        )
        {
            //deze functie haalt reservaties op uit de database vanuit de repository en mapt de vanuit het type List<Reservation>
            //om naar het type UnAvailableDatesDto. dit doet hij doormiddel van een custom resolver die ik geschreven heb om de datums
            // uit te kunen rekenen. de resolver is te vinden in het Resolvers mapje in de Model map.
            return _mapper.Map<UnAvailableDatesDto>(
                await _entityRepository.UnAvailableDates(cancellationToken, Id)
            );
        }

        public async Task<ReservationResponseDto> StoreReservation(
            CancellationToken cancellationToken,
            ReservationRequestDto request
        )
        {
            //Als er niets mee gestuurd word met de request
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            //haal de customer uit de request met een mapper
            Customer customerFromRequest = _mapper.Map<Customer>(request);
            //kijken of de customer al bestaat
            var customer = await _entityRepository.GetCustomer(
                cancellationToken,
                customerFromRequest
            );
            //de locatie details ophalen
            var location = await _entityRepository.GetDetails(
                cancellationToken,
                request.LocationId
            );
            //haal de unavailable dates op die bij de locatie horen en haal de data op die gebruikt gaan worden
            //door de reservatie die nu aangemaakt word.
            var unAvailableDates = await UnAvailableDates(cancellationToken, location.Id);
            var requestDates = _mapper.Map<UnAvailableDatesDto>(request).UnAvailableDates;

            //als deze data overlappen met elkaar return een error
            bool hasDuplicate = unAvailableDates.UnAvailableDates.Intersect(requestDates).Any();
            if (hasDuplicate)
            {
                throw new InvalidOperationException(
                    "De geslecteerde data heeft al gereserveerde data ertussen"
                );
            }
            //als alles klopt maak reservatie aan
            var reservation = await _entityRepository.MakeReservation(
                cancellationToken,
                customer,
                request,
                location
            );
            //map de aangemaakte reservatie naar de responsedto
            return _mapper.Map<ReservationResponseDto>(reservation);
        }
    }
}
