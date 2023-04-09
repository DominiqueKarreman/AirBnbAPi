using Api.Data;
using Api.Model;
using Api.Model.DTO;
using Microsoft.EntityFrameworkCore;
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
      public async Task<IEnumerable<Location>> Search(CancellationToken cancellationToken, SearchDto search)
      {
         /*var locations = _context.Location.Where()*/
         Console.WriteLine(search);
         if (search.Features == null && search.Rooms == null && search.MinPrice == null && search.MaxPrice == null)
         {
            var locationsWithoutFilterAndRooms =  await _context.Location.Include(location => location.Landlord).ThenInclude(landlord => landlord.Avatar).Include(location => location.Images).ToListAsync(cancellationToken);
            return locationsWithoutFilterAndRooms;
         }
         else if (search.Features == null && search.MinPrice == null && search.MaxPrice == null)
         {
            var locationsWithoutFilter = await _context.Location.Include(location => location.Landlord).ThenInclude(landlord => landlord.Avatar).Include(location => location.Images).Where(location => location.Rooms >= search.Rooms).ToListAsync(cancellationToken);
            return locationsWithoutFilter;
         }
         return new List<Location>();
      }
   }
}
