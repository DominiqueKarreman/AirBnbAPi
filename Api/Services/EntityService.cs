using Api.Model;
using Api.Model.DTO;
using Api.Repositories;
using AutoMapper;
using Microsoft.CodeAnalysis;

namespace Api.Services

{
   public class EntityService : IEntityService
   {
      private readonly IEntityRepository _entityRepository;
      private readonly IMapper _mapper;

      public EntityService(IEntityRepository entityRepository, IMapper mapper)
      {
         _entityRepository = entityRepository;
         _mapper = mapper;
      }

      public IEnumerable<Landlord> GetAllLandlords()
      {
         return _entityRepository.GetAllLandlords();
      }

      public async Task<IEnumerable<LocationDto>> GetAllLocations(CancellationToken cancellationToken)
      {
         var locations = await _entityRepository.GetAllLocations(cancellationToken);
         var locationDtos = locations.Select(location => _mapper.Map<LocationDto>(location));
         return locationDtos;

      }

      public Landlord GetLandlord(int id)
      {
         throw new NotImplementedException();
      }

      public async Task<IEnumerable<LocationWithImageDto>> GetLocationsWithImage(CancellationToken cancellationToken)
      {
         var locations = await _entityRepository.GetLocationsWithImage(cancellationToken);
         var locationDtos = _mapper.Map<IEnumerable<LocationWithImageDto>>(locations);
         return locationDtos;
      }
      public async Task<IEnumerable<LocationWithPriceDto>> GetLocationsWithPrice(CancellationToken cancellationToken)
      {
         var locations = await _entityRepository.GetLocationsWithImage(cancellationToken);
         var locationDtos = _mapper.Map<IEnumerable<LocationWithPriceDto>>(locations);
         return locationDtos;
      }
      public async Task<PriceDto> GetMaxPrice(CancellationToken cancellationToken)
      {
         var MaxPrice = await _entityRepository.GetMaxPrice(cancellationToken);
         var priceDto = new PriceDto()
         {
            Price = MaxPrice
         };
         return priceDto;

      }
      public async Task<DetailDto> GetDetails(CancellationToken cancellationToken, int Id)
      {
         var location = await _entityRepository.GetDetails(cancellationToken, Id);
         var detailDto = _mapper.Map<DetailDto>(location);
         return detailDto;
      }
  

      public async Task<UnAvailableDatesDto> UnAvailableDates(CancellationToken cancellationToken, int Id)
      {
         var reservations = await _entityRepository.UnAvailableDates(cancellationToken, Id);
         List<ResidenceFromDto> residences = new List<ResidenceFromDto>();
         UnAvailableDatesDto restrictedDates = new UnAvailableDatesDto();
         foreach (var reservation in reservations)
         {

            ResidenceFromDto residence = new(reservation.StartDate, reservation.EndDate);
            residence.GetDatesBetween();
            foreach (var date in residence.Dates)
            {
               restrictedDates.UnAvailableDates.Add(date.Date);
            }
         }
         return restrictedDates;
      }
   }
}
