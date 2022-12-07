﻿using Backend.Logic;
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
        public IActionResult GetLevels()
        {
            try
            {
                List<LevelViewModel> levels = _logic.GetLevels();

                return Ok(levels);
            }
            catch
            {
                return NotFound();
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
