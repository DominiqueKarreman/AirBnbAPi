using Api.Model.DTO;
using Api.Model;

namespace Api.Services
{
   public interface IEntityService
   {
      public IEnumerable<Landlord> GetAllLandlords();
      public Landlord GetLandlord(int id);

      public IEnumerable<Location> GetAllLocations();
      public IEnumerable<LocationWithImageDto> GetLocationsWithImage();
   }
}
