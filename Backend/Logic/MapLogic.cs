using Backend.Models.BusinessModels;
using Backend.Repositories;
using Backend.Repositories.Interfaces;

namespace Backend.Logic
{
    public class MapLogic
    {
        private readonly IMapRepository _repo;
        public MapLogic(IMapRepository repo)
        {
            _repo = repo;
        }

        public List<Building> GetBuildings()
        {
            return _repo.GetBuildings();
        }
    }
}
