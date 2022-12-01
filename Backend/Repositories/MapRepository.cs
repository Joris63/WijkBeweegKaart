using Backend.Context;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class MapRepository : IMapRepository
    {
        private readonly MapContext _context;
        public MapRepository(MapContext context)
        {
            _context = context;
        }

        public List<BuildingDTO> GetBuildings() 
        {
            return _context.Buildings.ToList();
        }
    }
}
