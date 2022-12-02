using Backend.Logic;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}
