using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class UserLevelDTO
    {
        [Key]
        public int Id { get; set; }
        public UserDTO user { get; set; }
        public LevelDTO level { get; set; }
    }
}
