using Backend.Context;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly BackendContext _context;

        public LevelRepository(BackendContext context)
        {
            _context = context;
        }

        public LevelDTO GetLevelBySurveyId(string surveyId)
        {
            return _context.Levels.Where(l => l.SurveyId == surveyId).FirstOrDefault();
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
                SurveyId = level.SurveyId,
                SurveyPage = level.SurveyPage,
                SurveyName = level.SurveyName,
                PreviousLevelId = level.PreviousLevelId
            };

            _context.Levels.Add(newLevel);
            _context.SaveChanges();

            return newLevel;
        }
    }
}
