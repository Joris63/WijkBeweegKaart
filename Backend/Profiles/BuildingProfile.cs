using AutoMapper;
using Backend.Models.ViewModels;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;

namespace Backend.Profiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<BuildingViewModel, Building>().ReverseMap();
            CreateMap<BuildingDTO, Building>().ReverseMap();
        }
    }
}
