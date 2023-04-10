using Api.Model.DTO;
using Api.Model;
using Api.Repositories;
using AutoMapper;

namespace Api.Services
{
   public class SearchService : ISearchService
   {
      private readonly IEntityRepository _entityRepository;
      private readonly IMapper _mapper;


      public SearchService(IEntityRepository entityRepository, IMapper mapper)
      {
         _entityRepository = entityRepository;
         _mapper = mapper;
      }
      public async Task<IEnumerable<LocationWithPriceDto>> Search(CancellationToken cancellationToken, SearchDto search)
      {
         var locations = await _entityRepository.GetLocationsWithPrice(cancellationToken);
         if (search.Features.HasValue)
         {
            locations = locations.Where(location => (int)location.Features == search.Features);
         }
         if (search.MinPrice.HasValue)
         {
            locations = locations.Where(location => location.PricePerDay >= search.MinPrice);
         }
         if (search.MaxPrice.HasValue)
         {
            locations = locations.Where(location => location.PricePerDay <= search.MaxPrice);
         }
         if (search.Type.HasValue)
         {
            locations = locations.Where(location => (int)location.Type == search.Type);
         }
         if (search.Rooms.HasValue)
         {
            locations = locations.Where(location => location.Rooms >= search.Rooms);
         }
         var locationDtos = _mapper.Map<IEnumerable<LocationWithPriceDto>>(locations);
         return locationDtos;
      }
   }
}
