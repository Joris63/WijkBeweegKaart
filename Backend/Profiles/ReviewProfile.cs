using AutoMapper;
using Backend.Models.ViewModels;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;

namespace Backend.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewViewModel, Review>().ReverseMap();
            CreateMap<ReviewDTO, Review>().ReverseMap();
        }
    }
}
