using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public UserDTO GetUserById(int id);
        public UserDTO LoginEmail(string email, string password);
        public UserDTO LoginUsername(string username, string password);
        public UserDTO SaveUserEmail(string email, string password);
        public UserDTO SaveUserUsername(string username, string password);
        public UserDTO SaveFullUser(string username, string email, string password);
    }
}
