using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IMapRepository
    {
        public MapDTO GetMapById(int id);
        public MapDTO SaveMap(MapDTO map);
        public List<BuildingDTO> GetBuildings();
    }
}
