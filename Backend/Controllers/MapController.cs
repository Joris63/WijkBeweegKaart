using Backend.Logic;
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

        public ActionResult Index() 
        {
            return Ok(_logic.GetBuildings());
        }
    }
}
