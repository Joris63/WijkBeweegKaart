using Backend.Context;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BackendContext _context;

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
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public UserDTO SaveUserEmail(int id, string email)
        {
            throw new NotImplementedException();
        }
    }
}
