using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface ILevelRepository
    {
        public LevelDTO SaveLevel(LevelDTO levelDTO);
        public List<LevelDTO> GetLevels();
        public List<UserLevelDTO> GetCompletedLevels(int userId);
        public LevelDTO GetLevelBySurveyId(int surveyId);
    }
}
