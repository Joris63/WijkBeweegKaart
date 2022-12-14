using Backend.Logic;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Reviews")]
    public class DonationController : Controller
    {
        private readonly ReviewLogic _logic;
        public DonationController(ReviewLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetDonationsByBuildingId(int Id)
        {
            try
            {
                List<DonationViewModel> reviews = _logic.GetDonationsByBuildingId(Id);

                return Ok(reviews);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult SaveDonation(BuildingDonationViewModel review)
        {
            try
            {
                _logic.SaveDonation(review);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { review, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { review, ex });
            }

            return Ok(review);
        }
    }
}
