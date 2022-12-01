using AutoMapper;
using Backend.Models.ViewModels;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;

namespace Backend.Profiles
{
    public class BuidlingProfile : Profile
    {
        public BuidlingProfile()
        {
            CreateMap<Building, BuildingViewModel>().ReverseMap();
            CreateMap<BuildingDTO, Building>().ReverseMap();
        }
    }
}
