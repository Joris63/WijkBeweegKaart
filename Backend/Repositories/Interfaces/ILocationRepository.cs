using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        public LocationDTO SaveLocation(LocationDTO locationDTO);
    }
}
