using Backend.Context;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BackendContext _context;

        public UserRepository(BackendContext context)
        {
            _context = context;
        }

        public UserDTO GetUserById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public UserDTO LoginEmail(string email, string password)
        {
            throw new NotImplementedException();
        }

        public UserDTO LoginUsername(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserDTO SaveUser(UserDTO user)
        {
            if(_context.Users.Where(u => u.Username == user.Username).Any())
            {
                throw new ArgumentException();
            }

            UserDTO newUser = new UserDTO()
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public UserDTO SaveUserEmail(int id, string email)
        {
            throw new NotImplementedException();
        }
    }
}
