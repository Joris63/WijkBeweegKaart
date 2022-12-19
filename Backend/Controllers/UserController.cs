using Backend.Helpers;
using Backend.Logic;
using Backend.Models.BusinessModels;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : Controller
    {
        private readonly UserLogic _logic;
        private readonly JwtService _jwtService;
        public UserController(UserLogic logic, JwtService jwtService)
        {
            _logic = logic;
            _jwtService = jwtService;
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetUserById(int Id)
        {
            try
            {
                UserViewModel map = _logic.GetUserById(Id);

                return Ok(map);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult SaveUser(RegisterLoginViewModel user)
        {
            try
            {
                user = _logic.SaveUser(user);

                return Ok(user);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { user, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { user, ex });
            }
            catch (ArgumentException ex)
            {
                return Conflict(new { user, ex });
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(RegisterLoginViewModel vm)
        {
            UserViewModel user = _logic.GetUserByUsername(vm.Username);
            if(user == null)
            {
                return BadRequest(new { message = "Invalid credentials" });
            }

            if(!BCrypt.Net.BCrypt.Verify(vm.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid credentials" });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new {message = "succes"});
        }
    }
}
