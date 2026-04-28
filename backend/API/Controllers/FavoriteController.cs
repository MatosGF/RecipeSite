using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly ILogger<FavoriteController> _logger;
        private readonly IFavoriteService _service;

        public FavoriteController(ILogger<FavoriteController> logger, IFavoriteService service)
        {
            _logger = logger;
            _service = service;
        }


        [Authorize]
        [HttpGet("is-favorite/{recipeId}")]
        public async Task<ActionResult<bool>> IsFavorite(int recipeId)
        {
            var userIdClaim = User.FindFirst("userId");

            if (userIdClaim == null)
                return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);

            return Ok(await _service.IsFavorite(userId, recipeId));
        }


        [Authorize]
        [HttpGet("my")]
        public async Task<IActionResult> MyFavorites()
        {
            var claim = User.FindFirst("userId")?.Value;

            return Ok(new
            {
                tokenUserId = claim,
                favorites = await _service.GetMyFavorites(int.Parse(claim))
            });
        }


        [Authorize]
        [HttpPost("toggle/{recipeId}")]
        public async Task<IActionResult> Toggle(int recipeId)
        {
            var userId = int.Parse(User.FindFirst("userId")!.Value);

            var added = await _service.Toggle(userId, recipeId);

            return Ok(new
            {
                success = true,
                isFavorite = added
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, FavoriteDto item)
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
                _logger.LogError(ex, "Error updating FavoriteDto with ID {{Id}}", id);
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
                _logger.LogError(ex, "Error deleting FavoriteDto with ID {{Id}}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
