namespace Backend.Models.ViewModels
{
    public class LevelViewModel
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public int? PreviousLevelId { get; set; }
        public bool Completed { get; set; }

        public LevelViewModel(int surveyId, string surveyName, int? previousLevelId)
        {
            this.SurveyId = surveyId;
            this.SurveyName = surveyName;
            this.PreviousLevelId = previousLevelId;
        }
    }
}
