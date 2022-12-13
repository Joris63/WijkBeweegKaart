using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Logic
{
    public class UserLevelLogic
    {
        private readonly IUserLevelRepository _repo;
        private readonly IMapper _mapper;
        public UserLevelLogic(IUserLevelRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<UserLevelViewModel> GetAllByUserId(int id)
        {
            List<UserLevel> userLevel = _mapper.Map<List<UserLevel>>(_repo.GetAllByUserId(id));

            if (userLevel == null)
            {
                throw new KeyNotFoundException();
            }

            return _mapper.Map<List<UserLevelViewModel>>(userLevel);
        }

        public UserLevelViewModel SaveUserLevel(UserLevelViewModel userLevelViewModel)
        {
            UserLevel userLevel = _mapper.Map<UserLevel>(userLevelViewModel);

            if (userLevel == null)
            {
                throw new ArgumentNullException();
            }

            if (userLevel.User == null || userLevel.Level == null)
            {
                throw new InvalidOperationException();
            }

            UserLevelDTO userLeveldto = _repo.SaveUserLevel(_mapper.Map<UserLevelDTO>(userLevel));

            if (userLeveldto.user.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<UserLevelViewModel>(_mapper.Map<UserLevel>(userLeveldto));
        }
    }
}
