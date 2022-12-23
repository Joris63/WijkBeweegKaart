using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;

namespace Backend.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationViewModel, Location>().ReverseMap();
            CreateMap<LocationDTO, Location>().ReverseMap();
        }
    }
}
