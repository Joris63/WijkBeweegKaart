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
            CreateMap<UserLevelDTO, UserLevel>().ReverseMap();
        }
    }
}
