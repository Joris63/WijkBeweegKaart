using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;

namespace Backend.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<RegionViewModel, Region>().ReverseMap();
            CreateMap<RegionDTO, Region>().ReverseMap();
        }
    }
}
