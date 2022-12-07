using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Logic
{
    public class UserLogic
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserLogic(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public UserViewModel GetUserById(int id)
        {
            User user = _mapper.Map<User>(_repo.GetUserById(id));

            if (user == null)
            {
                throw new KeyNotFoundException();
            }

            return _mapper.Map<UserViewModel>(user);
        }

        public UserViewModel SaveUser(UserViewModel userViewModel)
        {
            User user = _mapper.Map<User>(userViewModel);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            if (user.username == null || user.password == null)
            {
                throw new InvalidOperationException();
            }

            UserDTO userdto = _repo.SaveUser(_mapper.Map<UserDTO>(user));

            if (userdto.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<UserViewModel>(_mapper.Map<User>(userdto));
        }
    }
}
