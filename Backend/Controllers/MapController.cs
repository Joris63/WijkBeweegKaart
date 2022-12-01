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
        [Route("Buildings")]
        public ActionResult GetBuildings() 
        {
            ICollection<BuildingViewModel> buildings = _logic.GetBuildings();

            return Ok(buildings);
        }
    }
}
