using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;

namespace Backend.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MapViewModel, Map>().ReverseMap();
            CreateMap<SaveMapViewModel, Map>()
                .ForPath(dest => dest.Location.Id, act => act.MapFrom(s => s.LocationId));
            CreateMap<Map, MapDTO>().ReverseMap()
                .AfterMap((s, d) => 
                { 
                    foreach (Building building in d.PlacedBuildings)
                    {
                        building.CalculateLevel();
                    }
                });
        }
    }
}
