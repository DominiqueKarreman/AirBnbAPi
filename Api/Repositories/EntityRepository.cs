using Api.Data;
using Api.Model;
using Api.Model.DTO;
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

      public Landlord GetLandlord(int id)
      {
         return _context.Landlord.Find(id);
      }

      public IEnumerable<Landlord> GetAllLandlords()
      {
         return _context.Landlord.ToList();
      }

      public async Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken)
      {
         try
         {

            if (cancellationToken.IsCancellationRequested)
            {
               throw new TaskCanceledException();
            }
            return await _context.Location.ToListAsync(cancellationToken);
         }
         catch (TaskCanceledException ex)
         {
            Console.WriteLine(ex.Message, "cancelled");
            return Enumerable.Empty<Location>();
         }
      }
      public async Task<IEnumerable<Location>> GetLocationsWithImage(CancellationToken cancellationToken)
      {
         var locations = await _context.Location.Include(location => location.Landlord).ThenInclude(landlord => landlord.Avatar).Include(location => location.Images).ToListAsync(cancellationToken);  
         return locations;
      }
      public async Task<IEnumerable<Location>> GetLocationsWithPrice(CancellationToken cancellationToken)
      {
         var locations = await _context.Location.Include(location => location.Landlord).ThenInclude(landlord => landlord.Avatar).Include(location => location.Images).ToListAsync(cancellationToken);
         return locations;
      }
      public async Task<int> GetMaxPrice(CancellationToken cancellationToken)
      {

         return await _context.Location.MaxAsync(location => (int)location.PricePerDay, cancellationToken); 

      }
      public async Task<Location> GetDetails(CancellationToken cancellationToken, int Id)
      {
         return await _context.Location.Include(location => location.Landlord).ThenInclude(landlord => landlord.Avatar).Include(location => location.Images).Where(location => location.Id == Id).FirstOrDefaultAsync(cancellationToken);
      }

      public async Task<IEnumerable<Reservation>> UnAvailableDates(CancellationToken cancellationToken, int Id)
      {
    
         var reservations = await _context.Reservation.Where(reservation => reservation.LocationId == Id).ToListAsync(cancellationToken);
      
         return reservations;
      }
   }
}
