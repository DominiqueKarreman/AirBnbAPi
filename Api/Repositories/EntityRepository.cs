using Api.Data;
using Api.Model;
using Api.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using NuGet.Common;

namespace Api.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly ApiContext _context;

        public EntityRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllLocations(
            CancellationToken cancellationToken
        )
        {
            //Deze functie haalt alle locaties op uit de database vanuit de context.
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is IEnumerable Location. dus we verwachten een lijst van locaties.
            return await _context.Location.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Location>> GetAllLocationsV2(
            CancellationToken cancellationToken
        )
        {
            //Deze functie haalt alle locaties op uit de database vanuit de context. en include alle
            //andere geimplimenteerde modellen
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is IEnumerable Location. dus we verwachten een lijst van locaties.
            return await _context.Location
                .Include(location => location.Landlord)
                .ThenInclude(landlord => landlord.Avatar)
                .Include(location => location.Images)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetMaxPrice(CancellationToken cancellationToken)
        {
            //Deze functie haalt de hoogste prijs op uit de database vanuit de context.
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is int. dus we verwachten een getal
            return await _context.Location.MaxAsync(
                location => (int)location.PricePerDay,
                cancellationToken
            );
        }

        public async Task<Location> GetDetails(CancellationToken cancellationToken, int Id)
        {
            //Deze functie haalt alle details van de locatie op uit de database vanuit de context.
            //met Id: {id}
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is  Location. dus we verwachten een locatie
            return await _context.Location
                    .Include(location => location.Landlord)
                    .ThenInclude(landlord => landlord.Avatar)
                    .Include(location => location.Images)
                    .Include(location => location.Reservations)
                    .Where(location => location.Id == Id)
                    .FirstOrDefaultAsync(cancellationToken)
                ?? throw new KeyNotFoundException("Locatie met id: " + Id + " was niet gevonden");
        }

        public async Task<List<Reservation>> UnAvailableDates(
            CancellationToken cancellationToken,
            int Id
        )
        {
            //Deze functie haalt alle reservaties op van de locatie op uit de database vanuit de context.
            //met Id: {id}
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is  List<Reservation> . dus we verwachten een lijst met reservaties
            var reservations = await _context.Reservation
                .Where(reservation => reservation.LocationId == Id)
                .ToListAsync(cancellationToken);

            return reservations;
        }

        public async Task<Customer> GetCustomer(
            CancellationToken cancellationToken,
            Customer customerFromRequest
        )
        {
            //Deze functie haalt de customer op uit de database waar de email customerFromRequest.email is
            //als de customer niet gevonden word. word deze aangemaakt met het customerFromRequest object
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is Customer. dus we verwachten een Customer
            var customer = await _context.Customer
                .Where(customer => customer.Email == customerFromRequest.Email)
                .FirstOrDefaultAsync(cancellationToken);
            if (customer == null)
            {
                customer = customerFromRequest;
                await _context.Customer.AddAsync(customer, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return customer;
        }

        public async Task<Reservation> MakeReservation(
            CancellationToken cancellationToken,
            Customer customer,
            ReservationRequestDto request,
            Location location
        )
        {
            //Deze functie slaat de reservatie op in de database
            //Er word een cancellation token mee gegeven zodat de request geannuleerd kan worden.
            //het response type is Resrvation. dus we verwachten een Reservation
            var reservation = new Reservation()
            {
                LocationId = location.Id,
                Location = location,
                Customer = customer,
                Discount = request.Discount ?? 0,
                CustomerId = customer.Id,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };
            await _context.Reservation.AddAsync(reservation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return reservation;
        }
    }
}
