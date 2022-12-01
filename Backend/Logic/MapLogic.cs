using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.ViewModels;
using Backend.Repositories;
using Backend.Repositories.Interfaces;

namespace Backend.Logic
{
    public class MapLogic
    {
        private readonly IMapRepository _repo;
        private readonly IMapper _mapper;
        public MapLogic(IMapRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<BuildingViewModel> GetBuildings()
        {
            List<Building> Buildings = _mapper.Map<List<Building>>(_repo.GetBuildings());
            //magic
            return _mapper.Map<List<BuildingViewModel>>(Buildings);
        }
    }
}
