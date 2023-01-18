namespace Backend.Models.ViewModels
{
    public class LevelViewModel
    {
        public int Id { get; set; }
        public string SurveyId { get; set; }
        public int SurveyPage { get; set; }
        public string SurveyName { get; set; }
        public int? PreviousLevelId { get; set; }
        public bool Completed { get; set; }

        public LevelViewModel(string surveyId, string surveyName, int? previousLevelId)
        {
            this.SurveyId = surveyId;
            this.SurveyName = surveyName;
            this.PreviousLevelId = previousLevelId;
        }
    }
}
