using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public RegisterLoginViewModel SaveUser(RegisterLoginViewModel vm)
        {
            User user = _mapper.Map<User>(vm);
            user.HashPassword();

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new InvalidOperationException();
            }

            UserDTO userdto = _repo.SaveUser(_mapper.Map<UserDTO>(user));

            if (userdto.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<RegisterLoginViewModel>(_mapper.Map<User>(userdto));
        }

        public UserViewModel GetUserByUsername(string username)
        {
            User user = _mapper.Map<User>(_repo.GetUserByUsername(username));

            if (user == null)
            {
                throw new KeyNotFoundException();
            }

            return _mapper.Map<UserViewModel>(user);
        }


    }
}
