using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class LevelDTO
    {
        [Key]
        public int Id { get; set; }
        public int surveyId { get; set; }
        public string surveyName { get; set; }
        public int? previousSurveyId { get; set; }
        public ICollection<UserDTO> users { get; set; }
    }
}
