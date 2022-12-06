namespace Backend.Models.BusinessModels
{
    public class LevelViewModel
    {
        public int surveyId { get; set; }
        public string surveyName { get; set; }
        public int? previousSurveyId { get; set; }

        public LevelViewModel(int surveyId, string surveyName, int? previousSurveyId)
        {
            this.surveyId = surveyId;
            this.surveyName = surveyName;
            this.previousSurveyId = previousSurveyId;
        }
    }
}
