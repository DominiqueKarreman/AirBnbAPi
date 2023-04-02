using Api.Model;
using Api.Model.DTO;
using Api.Repositories;

namespace Api.Services

{
   public class EntityService : IEntityService
   {
      private readonly IEntityRepository _entityRepository;
   
      public EntityService(IEntityRepository entityRepository)
      {
         _entityRepository = entityRepository;
      }

      public IEnumerable<Landlord> GetAllLandlords()
      {
         return _entityRepository.GetAllLandlords();
      }

      public IEnumerable<Location> GetAllLocations()
      {
         return _entityRepository.GetAllLocations();
      }

      public Landlord GetLandlord(int id)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<LocationWithImageDto> GetLocationsWithImage()
      {
          return _entityRepository.GetLocationsWithImage();
      }
   }
}
