using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class LevelDTO
    {
        [Key]
        public int Id { get; set; }
        public string SurveyId { get; set; }
        public int SurveyPage { get; set; }
        public string SurveyName { get; set; }
        public int? PreviousLevelId { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
