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
            return _context.Maps.Where(m => m.Id == id).Include(m => m.PlacedBuildings).FirstOrDefault();
        }

        public List<MapDTO> GetMapsFromUser(int userId)
        {
            return _context.Maps.Where(m => m.UserId == userId).ToList();
        }

        public List<BuildingDTO> GetBuildings() 
        {
            return _context.Buildings.ToList();
        }

        public MapDTO SaveMap(MapDTO map)
        {
            MapDTO newMap = new MapDTO()
            {
                Latitude = map.Latitude,
                Longitude = map.Longitude,
                PlacedBuildings = map.PlacedBuildings,
                UserId = map.UserId,
                Name = map.Name
            };

            _context.Maps.Add(newMap);
            _context.SaveChanges();

            return newMap;
        }
    }
}
