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
        public UserController(UserLogic logic)
        {
            _logic = logic;
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
        public IActionResult SaveUser(UserViewModel user)
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
    }
}
