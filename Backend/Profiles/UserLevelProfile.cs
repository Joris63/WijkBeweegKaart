using AutoMapper;
using Backend.Models.ViewModels;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;

namespace Backend.Profiles
{
    public class UserLevelProfile : Profile
    {
        public UserLevelProfile()
        {
            CreateMap<UserLevelViewModel, UserLevel>().ReverseMap();
            CreateMap<CompleteLevelViewModel, UserLevel>()
                .ForPath(dest => dest.User.Id, opt => opt.MapFrom(src => src.UserId))
                .ForPath(dest => dest.Level.Id, opt => opt.MapFrom(src => src.LevelId));
            CreateMap<UserLevelDTO, UserLevel>().ReverseMap();
        }
    }
}
