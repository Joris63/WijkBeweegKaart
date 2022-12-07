using Backend.Context;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UserLevelRepository : IUserLevelRepository
    {
        private readonly BackendContext _context;

        public UserLevelRepository(BackendContext context)
        {
            _context = context;
        }

        public List<UserLevelDTO> GetAllByUserId(int userId)
        {
            return _context.UserLevels.Where(ul => ul.user.Id == userId).ToList();
        }

        public UserLevelDTO SaveUserLevel(UserLevelDTO userLevel)
        {
            throw new NotImplementedException();
        }
    }
}
