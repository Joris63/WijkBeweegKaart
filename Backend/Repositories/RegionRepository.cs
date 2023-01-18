using Backend.Context;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly BackendContext _context;
        public RegionRepository(BackendContext context)
        {
            _context = context;
        }

        public RegionDTO SaveRegion(RegionDTO region)
        {
            RegionDTO RegionToSave = new RegionDTO
            {
                LocationId = region.LocationId,
                Points = region.Points
            };

            _context.Regions.Add(RegionToSave);
            _context.SaveChanges();

            return RegionToSave;
        }
    }
}
