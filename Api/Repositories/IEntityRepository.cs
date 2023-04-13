using Api.Model;
using Api.Model.DTO;
using System.Threading;

namespace Api.Repositories
{
    /// <summary>
    /// Interface voor het ophalen van gegevens uit de database.
    /// </summary>
    public interface IEntityRepository
    {
        /// <summary>
        /// Haalt alle locaties op uit de database.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Een lijst met locaties.</returns>
        public Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken);

        /// <summary>
        /// Haalt alle locaties op uit de database.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Een lijst met locaties.</returns>
        public Task<IEnumerable<Location>> GetAllLocationsV2(CancellationToken cancellationToken);

        /// <summary>
        /// Haalt een klant op uit de database.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <param name="customerFromRequest">customerFromRequest.</param>
        /// <returns>customer</returns>
        public Task<Customer> GetCustomer(
            CancellationToken cancellationToken,
            Customer customerFromRequest
        );

        /// <summary>
        /// Haalt de hoogste prijs op uit de database.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>De hoogste prijs.</returns>
        public Task<int> GetMaxPrice(CancellationToken cancellationToken);

        /// <summary>
        /// Haalt de details van een locatie op uit de database.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <param name="Id">Locatie-ID.</param>
        /// <returns>Een locatie.</returns>
        public Task<Location> GetDetails(CancellationToken cancellationToken, int Id);

        /// <summary>
        /// Maakt een nieuwe reservering aan en slaat deze op in de database.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <param name="customer">customer.</param>
        /// <param name="request">request.</param>
        /// <param name="location">Locatieobject.</param>
        /// <returns>Een Reservering.</returns>
        public Task<Reservation> MakeReservation(
            CancellationToken cancellationToken,
            Customer customer,
            ReservationRequestDto request,
            Location location
        );

        /// <summary>
        /// Haalt de lijst met unavailabledates van een locatie op uit de database.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <param name="Id">Locatie-ID.</param>
        /// <returns>Een lijst met reserveringen.</returns>
        public Task<List<Reservation>> UnAvailableDates(
            CancellationToken cancellationToken,
            int Id
        );
    }
}
