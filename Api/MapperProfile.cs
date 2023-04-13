using AutoMapper;
using Api.Model;
using Api.Model.Resolvers;
using Api.Model.DTO;
using Api.Model.Resolvers.Api.Model.Resolvers;

namespace Services
{
    public class MapperProfile : Profile
    {
      public MapperProfile()
      {
         CreateMap<Landlord, LandlordDto>();
         CreateMap<int, PriceDto>();

         CreateMap<ReservationRequestDto, Customer>();
         CreateMap<int, PriceDto>()
         .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src));

         CreateMap<Reservation, ReservationResponseDto>()
             .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Title))
             .ForMember(
                 dest => dest.CustomerName,
                 opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName)
             )
             .ForMember(dest => dest.Price, opt => opt.MapFrom<ReservationToPriceResolver>());

         CreateMap<Location, LocationWithImageDto>()
             .ForMember(
                 location => location.ImageURL,
                 opt =>
                     opt.MapFrom(
                         src => src.Images.Where(i => i.IsCover == true).FirstOrDefault().Url
                     )
             );
         CreateMap<Location, LocationWithPriceDto>()
             .ForMember(
                 location => location.ImageURL,
                 opt =>
                     opt.MapFrom(
                         src => src.Images.Where(i => i.IsCover == true).FirstOrDefault().Url
                     )
             )
             .ForMember(location => location.Price, opt => opt.MapFrom(src => src.PricePerDay));
         CreateMap<Location, DetailDto>()
             .ForMember(
                 location => location.Images,
                 opt => opt.MapFrom(src => src.Images.ToList())
             )
             .ForMember(
                 location => location.Features,
                 opt => opt.MapFrom(src => (int)src.Features)
             );
         CreateMap<List<Reservation>, UnAvailableDatesDto>()
            .ForMember(dest => dest.UnAvailableDates, opt => opt.MapFrom<UnAvailableDatesResolver>());

         CreateMap<ReservationRequestDto, UnAvailableDatesDto>()
      .ForPath(dest => dest.UnAvailableDates, opt => opt.MapFrom(src => new ReservationRequestToDatesListResolver(src.StartDate, src.EndDate).Dates));




      }
   }
}
