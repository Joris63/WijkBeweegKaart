using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class UserLevelDTO
    {
        public int userId { get; set; }
        public int levelId { get; set; }
        public UserDTO user { get; private set; }
        public LevelDTO level { get; private set; }
    }
}
