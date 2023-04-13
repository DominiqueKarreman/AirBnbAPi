using Api.Model.DTO;
using Api.Model;
using System.Threading;

namespace Api.Services
{
    public interface IEntityService
    {
        /// <summary>
        /// Haalt alle locaties op.
        /// </summary>
        /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
        /// <returns>Een lijst van alle locaties.</returns>
        public Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken);

        /// <summary>
        /// Haalt alle locaties op, inclusief foto
        /// </summary>
        /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
        /// <returns>Een lijst van alle locaties met foto.</returns>
        public Task<IEnumerable<LocationWithImageDto>> GetLocationsWithImage(
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Haalt alle locaties op, inclusief prijs
        /// </summary>
        /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
        /// <returns>Een lijst van alle locaties met prijs.</returns>
        public Task<IEnumerable<LocationWithPriceDto>> GetLocationsWithPrice(
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Haalt de maximale prijs van alle locaties op.
        /// </summary>
        /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
        /// <returns>De hoogste prijs van alle locaties.</returns>
        public Task<PriceDto> GetMaxPrice(CancellationToken cancellationToken);

        /// <summary>
        /// Haalt details op van een locatie met id: {id}
        /// </summary>
        /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
        /// <param name="Id">De Id van de locatie waarvoor details worden opgehaald.</param>
        /// <returns>Een object met de details van de locatie.</returns>
        public Task<DetailDto> GetDetails(CancellationToken cancellationToken, int Id);

        /// <summary>
        /// Haalt unavailabledates op voor een specifieke locatie.
        /// </summary>
        /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
        /// <param name="Id">De Id van de locatie waarvoor unavailable dates worden opgehaald.</param>
        /// <returns>unavailable dates van de locatie.</returns>
        public Task<UnAvailableDatesDto> UnAvailableDates(
            CancellationToken cancellationToken,
            int Id
        );

        /// <summary>
        /// Slaat een nieuwe reservering op.
        /// </summary>
        /// <param name="cancellationToken">Een CancellationToken om de operatie te annuleren indien nodig.</param>
        /// <param name="request">De gegevens van de nieuwe reservering.</param>
        /// <returns>ReservationResponseDto van de opgeslagen reservering.</returns>
        public Task<ReservationResponseDto> StoreReservation(
            CancellationToken cancellationToken,
            ReservationRequestDto request
        );
    }
}
