using Backend.Context;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly BackendContext _context;

        public LevelDTO GetLevelBySurveyId(int surveyId)
        {
            return _context.Levels.Where(l => l.surveyId == surveyId).FirstOrDefault();
        }

        public List<LevelDTO> GetLevels()
        {
            return _context.Levels.ToList();
        }

        public List<UserLevelDTO> GetCompletedLevels(int userId)
        {
            return _context.UserLevels.Where(ul => ul.userId == userId).ToList();
        }

        public LevelDTO SaveLevel(LevelDTO level)
        {
            LevelDTO newLevel = new LevelDTO()
            {
                surveyId = level.surveyId,
                surveyName = level.surveyName,
                previousSurveyId = level.previousSurveyId
            };

            _context.Levels.Add(newLevel);
            _context.SaveChanges();

            return newLevel;
        }
    }
}
