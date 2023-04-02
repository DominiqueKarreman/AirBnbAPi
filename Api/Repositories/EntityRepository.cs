using Api.Data;
using Api.Model;
using Api.Model.DTO;

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

      public IEnumerable<Location> GetAllLocations()
      {
        return _context.Location.ToList();
      }
      public IEnumerable<LocationWithImageDto> GetLocationsWithImage()
      {
         var locations = _context.Location.ToList();
         List<LocationWithImageDto> locationsDtoList = new List<LocationWithImageDto>();
         foreach (var location in locations)
         {
            Landlord landlord = _context.Landlord.Find(location.LandlordId);
            Image landLordAvatarURL = _context.Image.Find(landlord.AvatarId);
            LocationWithImageDto locationWithImageDto = new LocationWithImageDto()
            {
               Title = location.Title,
               SubTitle = location.SubTitle,
               Description = location.Description,
               landlordAvatarURL = landLordAvatarURL.Url,
               ImageURL = _context.Image.Where(i => i.LocationId == location.Id).First().Url
            };
            locationsDtoList.Add(locationWithImageDto);

         }
         return locationsDtoList;
      }
   }
}
