using Backend.Logic;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Maps")]
    public class MapController : Controller
    {
        private readonly MapLogic _logic;
        public MapController(MapLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{Id}")]
        [Authorize(Roles = "Admin")]
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
        public IActionResult SaveMap(SaveMapViewModel map)
        {
            try
            {
                MapViewModel newMap = _logic.SaveMap(map);
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
