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

            if (map != null)
            {
                if (map.longitude != 0 && map.latitude != 0 && map.placedBuildings.Count > 0)
                {
                    MapDTO mapdto = _repo.SaveMap(_mapper.Map<MapDTO>(map));

                    if (mapdto.Id > 0)
                    {
                        return _mapper.Map<MapViewModel>(_mapper.Map<Map>(mapdto));
                    }
                    else
                    {
                        throw new DbUpdateException();
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            throw new ArgumentNullException();
        }
    }
}
