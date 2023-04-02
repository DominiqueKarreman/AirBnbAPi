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
        }
    }
}
