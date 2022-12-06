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

        [HttpPost]
        [Route("Save")]
        public IActionResult SaveMap(MapViewModel Map)
        {
            try
            {
                _logic.SaveMap(Map);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Map, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Map, ex });
            }

            return Ok(Map);
        }
    }
}
