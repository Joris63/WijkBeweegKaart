using Backend.Context;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;

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
            UserLevelDTO newLevel = new UserLevelDTO()
            {
                userId = userLevel.userId,
                levelId = userLevel.levelId,
            };

            _context.UserLevels.Add(newLevel);
            _context.SaveChanges();

            return newLevel;
        }
    }
}
