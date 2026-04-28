using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dtos;
using Models.Entities;
using Repository.Context;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _service;
        private readonly DbContextRecipe _context;

        public RecipeController(ILogger<RecipeController> logger, IRecipeService service, DbContextRecipe context)
        {
            _logger = logger;
            _service = service;
            _context = context;
        }

        // ========================
        // GET ALL
        // ========================
        [HttpGet]
        [AllowAnonymous] // Se quiser manter público
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetAll()
        {
            var items = await _service.GetAll();
            return Ok(items);
        }

        [HttpGet("approved")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetApproved()
        {
            var items = await _service.GetApprovedRecipes();
            return Ok(items);
        }


        [HttpGet("categories")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpGet("difficulties")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Difficulty>>> GetDifficulties()
        {
            return await _context.Difficulties.ToListAsync();
        }

        [HttpGet("ingredients")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            return await _context.Ingredients.ToListAsync();
        }


        // ========================
        // GET BY ID (DETALHES)
        // ========================
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<RecipeDto>> GetById(int id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.MeasurementType)
                .Include(r => r.Category)
                .Include(r => r.Difficulty)
                .Include(r => r.User)
                .Include(r => r.Ratings)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            return Ok(RecipeMapper.ToDto(recipe));
        }



        [HttpPost]
        public async Task<ActionResult<RecipeDto>> Create([FromBody] CreateRecipeDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // EXTRAIR USER ID DO TOKEN JWT
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
                if (userIdClaim == null)
                    return Unauthorized("Token inválido: userId não encontrado.");

                dto.UserId = int.Parse(userIdClaim.Value); // ?? CORREÇÃO PRINCIPAL

                var created = await _service.AddAsync(dto);
                return Ok(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar receita");
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        // ========================
        // UPLOAD IMAGE
        // ========================
        [HttpPost("upload-image")]
        [Consumes("multipart/form-data")]
        [SwaggerOperation(Summary = "Faz upload de uma imagem e retorna a URL gerada")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequest request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("Nenhum arquivo enviado.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(request.File.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            var imageUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
            return Ok(new { imageUrl });
        }

        // ========================
        // UPDATE
        // ========================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRecipeDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            try
            {
                var updated = await _service.Update(dto);
                return Ok(updated); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar receita");
                return StatusCode(500, "Erro interno no servidor");
            }
        }



        // ========================
        // DELETE
        // ========================
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }


        // ========================
        // APPROVE
        // ========================
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return NotFound();

            recipe.Status = "Approved";
            recipe.IsActive = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ========================
        // GET PENDING
        // ========================
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetPending()
        {
            var pending = await _service.GetPendingRecipes();
            return Ok(pending);
        }

        // ========================
        // GET USER RECIPES
        // ========================
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetUserRecipes(int userId)
        {
            var recipes = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Difficulty)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.MeasurementType)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return Ok(recipes.Select(r => RecipeMapper.ToDto(r)));
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> Search(string? search)
        {
            var result = await _service.SearchRecipes(search);
            return Ok(result);
        }


    }

    public class UploadImageRequest
    {
        [SwaggerSchema("Arquivo de imagem a ser enviado")]
        public IFormFile File { get; set; }
    }
}

