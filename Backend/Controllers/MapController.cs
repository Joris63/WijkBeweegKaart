using Backend.Logic;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Map")]
    public class MapController : Controller
    {
        private readonly MapLogic _logic;
        public MapController(MapLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetMapById(int Id)
        {
            try
            {
                MapViewModel map = _logic.GetMapById(Id);

                return Ok(map);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult GetMapsFromUser(int userId)
        {
            try
            {
                return Ok(_logic.GetMapsFromUser(userId));
            }
            catch(ArgumentException ex) 
            {
                return BadRequest(new { userId, ex });
            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult SaveMap(MapViewModel map)
        {
            try
            {
                map = _logic.SaveMap(map);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { map, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { map, ex });
            }

            return Ok(map);
        }
    }
}
