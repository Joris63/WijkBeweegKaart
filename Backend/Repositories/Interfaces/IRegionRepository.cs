using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        public RegionDTO SaveRegion(RegionDTO region);
    }
}
