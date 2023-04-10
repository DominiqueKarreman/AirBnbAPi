using Api.Model.DTO;
using Api.Model;
using System.Threading;

namespace Api.Services
{
   public interface IEntityService
   {
      public IEnumerable<Landlord> GetAllLandlords();
      public Landlord GetLandlord(int id);

      public Task<IEnumerable<LocationDto>> GetAllLocations(CancellationToken cancellationToken);
      public Task<IEnumerable<LocationWithImageDto>> GetLocationsWithImage(CancellationToken cancellationToken);
      public Task<IEnumerable<LocationWithPriceDto>> GetLocationsWithPrice(CancellationToken cancellationToken);
      public Task<PriceDto> GetMaxPrice(CancellationToken cancellationToken);
      public Task<DetailDto> GetDetails(CancellationToken cancellationToken, int Id);

      public Task<UnAvailableDatesDto> UnAvailableDates(CancellationToken cancellationToken, int Id);
     
   }
}
