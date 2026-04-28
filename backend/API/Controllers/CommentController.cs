using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _service;

        public CommentController(ILogger<CommentController> logger, ICommentService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAll()
        {
            try
            {
                var items = await _service.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all CommentDtos");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("recipe/{recipeId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByRecipe(int recipeId)
        {
            var result = await _service.GetByRecipe(recipeId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CommentCreateDto dto)
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "userId").Value);
            await _service.Create(dto, userId);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id, CommentDto item)
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
                _logger.LogError(ex, "Error updating CommentDto with ID {{Id}}", id);
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
                _logger.LogError(ex, "Error deleting CommentDto with ID {{Id}}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
