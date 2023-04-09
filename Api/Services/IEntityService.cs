using Api.Model.DTO;
using Api.Model;

namespace Api.Services
{
   public interface IEntityService
   {
      public IEnumerable<Landlord> GetAllLandlords();
      public Landlord GetLandlord(int id);

      public Task<IEnumerable<LocationDto>> GetAllLocations(CancellationToken cancellationToken);
      public Task<IEnumerable<LocationWithImageDto>> GetLocationsWithImage(CancellationToken cancellationToken);
      public Task<IEnumerable<LocationWithPriceDto>> GetLocationsWithPrice(CancellationToken cancellationToken);

   }
}
