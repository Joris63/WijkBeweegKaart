using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IMapRepository
    {
        public List<BuildingDTO> GetBuildings();
    }
}
