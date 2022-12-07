using Backend.Logic;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Review")]
    public class ReviewController : Controller
    {
        private readonly ReviewLogic _logic;
        public ReviewController(ReviewLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetReviewsByMapId(int Id)
        {
            try
            {
                List<ReviewViewModel> reviews = _logic.GetReviewsByMapId(Id);

                return Ok(reviews);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult SaveReview(ReviewViewModel review)
        {
            try
            {
                _logic.SaveReview(review);
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
