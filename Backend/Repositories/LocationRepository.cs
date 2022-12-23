using Backend.Context;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly BackendContext _context;
        public LocationRepository(BackendContext context)
        {
            _context = context;
        }

        public LocationDTO SaveLocation(LocationDTO locationDTO)
        {

            LocationDTO newLocation = new LocationDTO()
            {
                Latitude = locationDTO.Latitude,
                Longitude = locationDTO.Longitude,
                Name = locationDTO.Name,
                Regions = locationDTO.Regions
            };

            _context.Locations.Add(newLocation);
            _context.SaveChanges();

            return newLocation;
        }
    }
}
