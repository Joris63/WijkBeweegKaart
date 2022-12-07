using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Logic
{
    public class LevelLogic
    {
        private readonly ILevelRepository _repo;
        private readonly IMapper _mapper;
        public LevelLogic(ILevelRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public LevelViewModel GetLevelBySurveyId(int id)
        {
            Level level = _mapper.Map<Level>(_repo.GetLevelBySurveyId(id));

            if (level == null)
            {
                throw new KeyNotFoundException();
            }

            return _mapper.Map<LevelViewModel>(level);
        }

        public List<LevelViewModel> GetLevels()
        {
            List<Building> levels = _mapper.Map<List<Building>>(_repo.GetLevels());
            
            return _mapper.Map<List<LevelViewModel>>(levels);
        }

        public LevelViewModel SaveLevel(LevelViewModel levelViewModel)
        {
            Level level = _mapper.Map<Level>(levelViewModel);

            if (level != null)
            {
                if (level.surveyId != 0)
                {
                    LevelDTO leveldto = _repo.SaveLevel(_mapper.Map<LevelDTO>(level));

                    if (leveldto.Id > 0)
                    {
                        return _mapper.Map<LevelViewModel>(_mapper.Map<Level>(leveldto));
                    }
                    else
                    {
                        throw new DbUpdateException();
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            throw new ArgumentNullException();
        }
    }
}
