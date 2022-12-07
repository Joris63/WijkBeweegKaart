using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface ILevelRepository
    {
        public LevelDTO SaveLevel(int surveyId, string surveyName, int? previousSurvey);
        public List<LevelDTO> GetLevels();
        public LevelDTO GetLevelBySurveyId(int surveyId);
    }
}
