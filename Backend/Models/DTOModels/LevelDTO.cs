using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class LevelDTO
    {
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public int? PreviousSurveyId { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
