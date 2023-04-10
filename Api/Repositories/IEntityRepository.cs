using Api.Model;
using Api.Model.DTO;

namespace Api.Repositories
{
   public interface IEntityRepository
   {
      public IEnumerable<Landlord> GetAllLandlords();
      public Landlord GetLandlord(int id);
      public Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken);
      public Task<IEnumerable<Location>> GetLocationsWithImage(CancellationToken cancellationToken);
      public Task<IEnumerable<Location>> GetLocationsWithPrice(CancellationToken cancellationToken);

      public Task<int> GetMaxPrice(CancellationToken cancellationToken);
      public Task<Location> GetDetails(CancellationToken cancellationToken, int Id);
      public Task<IEnumerable<Reservation>> UnAvailableDates(CancellationToken cancellationToken, int Id);
   }
}
