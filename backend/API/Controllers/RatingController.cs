using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly ILogger<RatingController> _logger;
        private readonly IRatingService _service;

        public RatingController(ILogger<RatingController> logger, IRatingService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetAll()
        {
            try
            {
                var items = await _service.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all RatingDtos");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<RatingDto>> GetById(int id)
        {
            try
            {
                var item = await _service.GetById(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving RatingDto with ID {{Id}}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("recipe/{recipeId}/average")]
        [AllowAnonymous]
        public async Task<ActionResult<double>> GetAverageByRecipe(int recipeId)
        {
            var average = await _service.GetAverageByRecipe(recipeId);
            return Ok(average);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RatingDto dto)
        {
            var userId = int.Parse(User.FindFirst("userId")!.Value);
            dto.UserId = userId;

            var result = await _service.AddOrUpdate(dto);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("recipe/{recipeId}/my")]
        public async Task<IActionResult> GetMyRating(int recipeId)
        {
            var userId = int.Parse(User.FindFirst("userId")!.Value);

            var rating = await _service.GetUserRating(userId, recipeId);

            return Ok(rating);
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id, RatingDto item)
        {
            try
            {
                if (id != item.Id)
                {
                    return BadRequest("ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updated = await _service.Update(item);
                if (updated == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating RatingDto with ID {{Id}}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting RatingDto with ID {{Id}}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
