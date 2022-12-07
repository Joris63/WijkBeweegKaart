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
            List<Level> levels = _mapper.Map<List<Level>>(_repo.GetLevels());

            return _mapper.Map<List<LevelViewModel>>(levels);
        }

        public List<UserLevelViewModel> GetCompletedLevels(int userId)
        {
            List<UserLevel> levels = _mapper.Map<List<UserLevel>>(_repo.GetCompletedLevels(userId));

            return _mapper.Map<List<UserLevelViewModel>>(levels);
        }

        public LevelViewModel SaveLevel(LevelViewModel levelViewModel)
        {
            Level level = _mapper.Map<Level>(levelViewModel);

            if (level == null)
            {
                throw new ArgumentNullException();
            }

            if (level.surveyId == 0)
            {
                throw new InvalidOperationException();
            }

            LevelDTO leveldto = _repo.SaveLevel(_mapper.Map<LevelDTO>(levelViewModel));

            if (leveldto.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<LevelViewModel>(_mapper.Map<Level>(leveldto));
        }
    }
}
