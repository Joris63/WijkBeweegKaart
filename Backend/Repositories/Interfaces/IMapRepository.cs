using Backend.Models.BusinessModels;

namespace Backend.Repositories.Interfaces
{
    public interface IMapRepository
    {
        public List<Building> GetBuildings();
    }
}
