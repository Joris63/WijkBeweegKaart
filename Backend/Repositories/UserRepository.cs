using Backend.Context;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;
using System.Runtime.CompilerServices;

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
            var result = _context.Users.SingleOrDefault(u => u.Id == id);

            if (result == null)
            {
                throw new ArgumentException();
            }

            result.Email = email;
            _context.SaveChanges();
            return result;
        }

        public UserDTO GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public UserDTO CoinChange(int id, int coinAmount)
        {
            var result = _context.Users.SingleOrDefault(u => u.Id == id);

            if (result == null)
            {
                throw new ArgumentException();
            }

            result.Coins += coinAmount;
            _context.SaveChanges();
            return result;
        }
    }
}
