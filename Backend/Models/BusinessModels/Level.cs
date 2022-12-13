namespace Backend.Models.BusinessModels
{
    public class Level
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public int? PreviousSurveyId { get; set; }

        public Level()
        {

        }
        public Level(int surveyId, string surveyName, int? previousSurveyId)
        {
            this.SurveyId = surveyId;
            this.SurveyName = surveyName;
            this.PreviousSurveyId = previousSurveyId;
        }
    }
}
