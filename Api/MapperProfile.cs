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
            CreateMap<Location, LocationDto>();
         CreateMap<Location, LocationWithImageDto>()
           .ForMember(location => location.ImageURL, opt => opt.MapFrom(src => src.Images.Where(i => i.IsCover == true).FirstOrDefault().Url));
         CreateMap<Location, LocationWithPriceDto>()
          .ForMember(location => location.ImageURL, opt => opt.MapFrom(src => src.Images.Where(i => i.IsCover == true ).FirstOrDefault().Url))
          .ForMember(location => location.Price, opt => opt.MapFrom(src => src.PricePerDay));
       
      
      }
    }
}
