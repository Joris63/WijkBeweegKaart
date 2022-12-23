using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Logic
{
    public class LocationLogic
    {
        private readonly ILocationRepository _repo;
        private readonly IMapper _mapper;

        public LocationLogic(ILocationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public LocationViewModel SaveLocation(LocationViewModel locationViewModel)
        {
            Location location = _mapper.Map<Location>(locationViewModel);

            if (location == null)
            {
                throw new ArgumentNullException();
            }

            if (location.Latitude == 0 || location.Longitude == 0)
            {
                throw new InvalidOperationException();
            }

            LocationDTO locationDTO = _repo.SaveLocation(_mapper.Map<LocationDTO>(location));

            if (locationDTO.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<LocationViewModel>(_mapper.Map<Location>(locationDTO));
        }
    }
}
