using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public UserDTO GetUserById(int id);
        public UserDTO SaveUserEmail(int id, string email);
        public UserDTO SaveUser(UserDTO user);
        public UserDTO GetUserByUsername(string username);
        public int CoinChange(int id, int coinAmount);
    }
}
