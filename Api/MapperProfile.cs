using AutoMapper;
using Api.Model;
using Api.Model.DTO;

namespace Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Landlord, LandlordDto>();
            CreateMap<int, PriceDto>();

         CreateMap<ReservationRequestDto, Customer>();
         CreateMap<Reservation, ReservationResponseDto>()
       .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Title))
       .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
       .ForMember(dest => dest.Price, opt => opt.MapFrom<ReservationToPriceResolver>());

         CreateMap<Location, LocationDto>();
         CreateMap<Location, LocationWithImageDto>()
           .ForMember(location => location.ImageURL, opt => opt.MapFrom(src => src.Images.Where(i => i.IsCover == true).FirstOrDefault().Url));
         CreateMap<Location, LocationWithPriceDto>()
          .ForMember(location => location.ImageURL, opt => opt.MapFrom(src => src.Images.Where(i => i.IsCover == true ).FirstOrDefault().Url))
          .ForMember(location => location.Price, opt => opt.MapFrom(src => src.PricePerDay));
         CreateMap<Location, DetailDto>()
           .ForMember(location => location.Images, opt => opt.MapFrom(src => src.Images.ToList()))
           .ForMember(location => location.Features, opt => opt.MapFrom(src => (int)src.Features));
           

      }
      public class ReservationToPriceResolver : IValueResolver<Reservation, ReservationResponseDto, float>
      {
         public float Resolve(Reservation source, ReservationResponseDto destination, float destMember, ResolutionContext context)
         {
            TimeSpan timeBetweenStartEnd = source.EndDate - source.StartDate;
            int daysBetween = timeBetweenStartEnd.Days;
            float price = source.Location.PricePerDay * daysBetween;
            return price;
         }
      }
   }
}
