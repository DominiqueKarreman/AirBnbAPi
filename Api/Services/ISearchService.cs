using Api.Model.DTO;

namespace Api.Services
{
   public interface ISearchService
   {
      public Task<IEnumerable<LocationWithPriceDto>> Search(CancellationToken cancellationToken, SearchDto search);
   }
}
