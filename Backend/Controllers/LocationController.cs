using Backend.Logic;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Locations")]
    public class LocationController : Controller
    {
        private readonly LocationLogic _logic;
        public LocationController(LocationLogic logic)
        {
            _logic = logic;
        }

        [HttpPost]
        [Route("Save"), ActionName("Save Location")]
        public IActionResult SaveLocation(LocationViewModel location)
        {
            try
            {
                _logic.SaveLocation(location);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { location, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { location, ex });
            }

            return Created("Save Location", location);
        }
    }
}
