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
         var searched = await _entityRepository.Search(cancellationToken, search);
        
         var locationDtos = _mapper.Map<IEnumerable<LocationWithPriceDto>>(searched);
     
         return locationDtos;
      }
   }
}
