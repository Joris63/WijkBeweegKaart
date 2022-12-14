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
            CreateMap<BuildingDonationViewModel, Donation>()
                .ForPath(dest => dest.User.Id, act => act.MapFrom(source => source.UserId))
                .ForPath(dest => dest.Building.Id, act => act.MapFrom(source => source.BuildingId))
                .ForMember(dest => dest.Amount, act => act.MapFrom(source => source.Amount));

            CreateMap<DonationViewModel, Donation>().ReverseMap();
            CreateMap<DonationDTO, Donation>().ReverseMap()
                .ForMember(dest => dest.UserId, act => act.MapFrom(source => source.User.Id))
                .ForMember(dest => dest.BuildingId, act => act.MapFrom(source => source.Building.Id));
        }
    }
}
