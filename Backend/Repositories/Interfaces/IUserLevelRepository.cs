using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IUserLevelRepository
    {
        public List<UserLevelDTO> GetAllByUserId(int userId);
        public UserLevelDTO SaveUserLevel(UserDTO user, LevelDTO level);
    }
}
