using Backend.Logic;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Levels")]
    public class LevelController : Controller
    {
        private readonly LevelLogic _logic;
        private readonly UserLevelLogic _userLevelLogic;
        public LevelController(LevelLogic logic, UserLevelLogic userLevelLogic)
        {
            _logic = logic;
            _userLevelLogic = userLevelLogic;
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetLevelBySurveyId(int Id)
        {
            try
            {
                LevelViewModel level = _logic.GetLevelBySurveyId(Id);

                return Ok(level);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Overview")]
        public IActionResult GetLevels(int userId)
        {
            try
            {
                List<LevelViewModel> levels = _logic.GetLevels();

                List<UserLevelViewModel> completedlevels = _logic.GetCompletedLevels(userId);

                foreach(UserLevelViewModel userLevelViewModel in completedlevels)
                {
                    for(int i = 0; i < levels.Count; i++)
                    {
                        if(userLevelViewModel.Level.SurveyId == levels[i].SurveyId)
                        {
                            levels[i].Completed = true;
                        }
                    }
                }    

                return Ok(levels);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Complete")]
        public IActionResult CompleteLevel(CompleteLevelViewModel level)
        {
            try
            {
                _userLevelLogic.SaveUserLevel(level);
                return RedirectToAction("GetLevels", level.UserId);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { level, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { level, ex });
            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult SaveLevel(LevelViewModel level)
        {
            try
            {
                _logic.SaveLevel(level);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { level, ex });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { level, ex });
            }

            return Ok(level);
        }
    }
}
