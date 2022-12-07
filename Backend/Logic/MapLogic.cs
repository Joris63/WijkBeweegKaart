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
            List<Building> Buildings = _mapper.Map<List<Building>>(_repo.GetBuildings());
            //magic
            return _mapper.Map<List<BuildingViewModel>>(Buildings);
        }

        public List<MapViewModel> GetMapsFromUser(int userId)
        {
            if(userId !> 0)
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

            return _mapper.Map<MapViewModel>(map);
        }

        public MapViewModel SaveMap(MapViewModel mapViewModel)
        {
            Map map = _mapper.Map<Map>(mapViewModel);

            if (map == null)
            {
                throw new ArgumentNullException();
            }

            if (map.longitude == 0 || map.latitude == 0 || map.placedBuildings.Count == 0)
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
