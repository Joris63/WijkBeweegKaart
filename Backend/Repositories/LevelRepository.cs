using Backend.Context;
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
            throw new NotImplementedException();
        }

        public LevelDTO SaveLevel(int surveyId, string surveyName, int? previousSurvey)
        {
            throw new NotImplementedException();
        }
    }
}
