using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Logic
{
    public class RegionLogic
    {
        private readonly IRegionRepository _repo;
        private readonly IMapper _mapper;
        public RegionLogic(IRegionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public RegionViewModel SaveRegion(RegionViewModel regionViewModel)
        {
            Region region = _mapper.Map<Region>(regionViewModel);

            if (region == null)
            {
                throw new ArgumentNullException();
            }

            if (region.MapId == 0 || region.Points.IsNullOrEmpty())
            {
                throw new InvalidOperationException();
            }

            RegionDTO regionDto = _repo.SaveRegion(_mapper.Map<RegionDTO>(region));

            if (regionDto.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<RegionViewModel>(_mapper.Map<Region>(regionDto));
        }
        public List<RegionViewModel> SaveRegions(SaveRegionsViewModel regionsViewModel)
        {
            List<Region> regions = _mapper.Map<List<Region>>(regionsViewModel.Regions);

            for (int i = regions.Count -1; i >= 0; i--)
            {
                regions[i].MapId = regionsViewModel.MapId;
                if (regions[i] == null)
                {
                    throw new ArgumentNullException();
                }

                if (regions[i].MapId == 0 || regions[i].Points.IsNullOrEmpty())
                {
                    throw new InvalidOperationException();
                }

                RegionDTO regionDto = _repo.SaveRegion(_mapper.Map<RegionDTO>(regions[i]));

                if (regionDto.Id == 0)
                {
                    throw new DbUpdateException();
                }

                regions.Remove(regions[i]);
                regions.Add(_mapper.Map<Region>(regionDto));
            }

            return _mapper.Map<List<RegionViewModel>>(regions);
        }
    }
}
