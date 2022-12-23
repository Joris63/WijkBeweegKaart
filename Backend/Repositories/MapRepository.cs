﻿using Backend.Context;
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
            return _context.Maps.Where(m => m.Id == id).Include("PlacedBuildings.Donations").Include("Regions.Points").FirstOrDefault();
        }

        public List<MapDTO> GetMapsFromUser(int userId)
        {
            return _context.Maps.Where(m => m.UserId == userId)
                .Include("PlacedBuildings.Donations")
                .Include("Regions.Points").ToList();
        }

        public List<BuildingDTO> GetBuildings()
        {
            return _context.Buildings.ToList();
        }

        public MapDTO SaveMap(MapDTO map)
        {
            MapDTO newMap = new MapDTO()
            {
                Location = _context.Locations.FirstOrDefault(l => l.Id == map.LocationId),
                PlacedBuildings = map.PlacedBuildings,
                MapCreator = _context.Users.FirstOrDefault(u => u.Id == map.UserId),
                Name = map.Name
            };

            _context.Maps.Add(newMap);
            _context.SaveChanges();

            return newMap;
        }
    }
}
