using Backend.Logic;
using Backend.Models.BusinessModels;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionController : Controller
    {
        private readonly RegionLogic _logic;
        public RegionController(RegionLogic logic)
        {
            _logic = logic;
        }


        [HttpPost]
        [Route("Save"), ActionName("Save Region")]
        public IActionResult SaveRegion([FromBody] RegionViewModel RegionViewModel)
        {
            try
            {
                RegionViewModel region = _logic.SaveRegion(RegionViewModel);
                return CreatedAtAction("Save Region", region);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { RegionViewModel, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { RegionViewModel, ex });
            }
        }

        [HttpPost]
        [Route("Save/Multiple"), ActionName("Save Regions")]
        public IActionResult SaveRegions([FromBody] SaveRegionsViewModel RegionsViewModel)
        {
            try
            {
                ICollection<RegionViewModel> regions = _logic.SaveRegions(RegionsViewModel);
                return CreatedAtAction("Save Regions", regions);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { RegionsViewModel, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { RegionsViewModel, ex });
            }
        }
    }
}
