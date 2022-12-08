using AutoMapper;
using Backend.Models.ViewModels;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;

namespace Backend.Profiles
{
    public class LevelProfile : Profile
    {
        public LevelProfile()
        {
            CreateMap<LevelViewModel, Level>().ReverseMap();
            CreateMap<LevelDTO, Level>().ReverseMap();
        }
    }
}
