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
            CreateMap<ReviewMapViewModel, Review>()
                .ForPath(dest => dest.Writer.Id, act => act.MapFrom(source => source.UserId))
                .ForPath(dest => dest.ReviewedMap.Id, act => act.MapFrom(source => source.MapId))
                .ForMember(dest => dest.ReviewText, act => act.MapFrom(source => source.Review));

            CreateMap<ReviewViewModel, Review>().ReverseMap();
            CreateMap<ReviewDTO, Review>().ReverseMap()
                .ForMember(dest => dest.UserId, act => act.MapFrom(source => source.Writer.Id))
                .ForMember(dest => dest.MapId, act => act.MapFrom(source => source.ReviewedMap.Id));
        }
    }
}
