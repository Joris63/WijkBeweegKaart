using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Logic
{
    public class MapLogic
    {
        private readonly IMapRepository _repo;
        private readonly IMapper _mapper;
        public MapLogic(IMapRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<BuildingViewModel> GetBuildings()
        {
            List<Building> buildings = _mapper.Map<List<Building>>(_repo.GetBuildings());

            return _mapper.Map<List<BuildingViewModel>>(buildings);
        }

        public List<MapViewModel> GetMapsFromUser(int userId)
        {
            if(!(userId > 0))
            {
                throw new ArgumentException();
            }

            List<Map> maps = _mapper.Map<List<Map>>(_repo.GetMapsFromUser(userId));

            return _mapper.Map<List<MapViewModel>>(maps);
        }

        public MapViewModel GetMapById(int id)
        {
            Map map = _mapper.Map<Map>(_repo.GetMapById(id));

            if (map == null)
            {
                throw new KeyNotFoundException();
            }

            foreach (Building building in map.PlacedBuildings)
            {
                building.CalculateLevel();
            }

            return _mapper.Map<MapViewModel>(map);
        }

        public MapViewModel SaveMap(MapViewModel mapViewModel)
        {
            Map map = _mapper.Map<Map>(mapViewModel);

            if (map == null)
            {
                throw new ArgumentNullException();
            }

            if (map.Longitude == 0 || map.Latitude == 0 || map.PlacedBuildings.Count == 0)
            {
                throw new InvalidOperationException();
            }

            MapDTO mapdto = _repo.SaveMap(_mapper.Map<MapDTO>(map));

            if (mapdto.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<MapViewModel>(_mapper.Map<Map>(mapdto));
        }
    }
}
