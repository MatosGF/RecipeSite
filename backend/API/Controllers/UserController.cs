using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            try
            {
                var items = await _service.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all UserDto");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<UserDto>> GetById(int id)
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
                _logger.LogError(ex, "Error retrieving UserDto with ID {{Id}}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(UserDto item, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdItem = await _service.AddAsync(item);
                return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating UserDto");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UserDto item)
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
                _logger.LogError(ex, "Error updating UserDto with ID {{Id}}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _service.AuthenticateAsync(loginDto.Email, loginDto.Senha);

                if (user == null)
                    return Unauthorized("Email ou senha inválidos");

                // Aqui você pode gerar um token JWT, se quiser
                // ou apenas retornar os dados do usuário autenticado
                return Ok(new
                {
                    token = "aqui-vai-o-token-se-tiver",
                    usuario = user
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao fazer login");
                return StatusCode(500, "Erro interno no servidor");
            }
        }


        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var deleted = await _service.(id);
        //        if (!deleted)
        //        {
        //            return NotFound();
        //        }

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error deleting UserDto with ID {{Id}}", id);
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
