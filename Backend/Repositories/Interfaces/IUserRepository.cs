using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public UserDTO GetUserById(int id);
        public UserDTO LoginEmail(string email, string password);
        public UserDTO LoginUsername(string username, string password);
        public UserDTO SaveUserEmail(int id, string email);
        public UserDTO SaveUser(string username, string password);
    }
}
