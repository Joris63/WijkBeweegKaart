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
                .ForPath(dest => dest.writer.Id, act => act.MapFrom(source => source.userId))
                .ForPath(dest => dest.reviewedMap.Id, act => act.MapFrom(source => source.mapId))
                .ForMember(dest => dest.review, act => act.MapFrom(source => source.review));

            CreateMap<ReviewViewModel, Review>().ReverseMap();
            CreateMap<ReviewDTO, Review>().ReverseMap()
                .ForMember(dest => dest.UserId, act => act.MapFrom(source => source.writer.Id))
                .ForMember(dest => dest.MapId, act => act.MapFrom(source => source.reviewedMap.Id));
        }
    }
}
