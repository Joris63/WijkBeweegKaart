namespace Backend.Models.BusinessModels
{
    public class Level
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public int? PreviousLevelId { get; set; }

        public Level()
        {

        }
    }
}
