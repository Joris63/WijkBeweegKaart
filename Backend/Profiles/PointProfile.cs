using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;

namespace Backend.Profiles
{
    public class PointProfile : Profile
    {
        public PointProfile()
        {
            CreateMap<PointViewModel, Point>().ReverseMap();
            CreateMap<PointDTO, Point>().ReverseMap();
        }
    }
}
