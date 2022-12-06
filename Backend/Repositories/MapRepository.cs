using Backend.Context;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class MapRepository : IMapRepository
    {
        private readonly BackendContext _context;
        public MapRepository(BackendContext context)
        {
            _context = context;
        }
        public MapDTO GetMapById(int id)
        {
            return _context.Maps.Where(m => m.Id == id).Include(m => m.placedBuildings).FirstOrDefault();
        }

        public List<BuildingDTO> GetBuildings() 
        {
            return _context.Buildings.ToList();
        }

        public MapDTO SaveMap(MapDTO map)
        {
            _context.Maps.Add(map);
            _context.SaveChanges();

            return map;
        }
    }
}
