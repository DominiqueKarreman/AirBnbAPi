using Api.Model;
using Api.Model.DTO;

namespace Api.Repositories
{
   public interface IEntityRepository
   {
      public IEnumerable<Landlord> GetAllLandlords();
      public Landlord GetLandlord(int id);
      public IEnumerable<Location> GetAllLocations();
      public IEnumerable<LocationWithImageDto> GetLocationsWithImage();

      
   }
}
