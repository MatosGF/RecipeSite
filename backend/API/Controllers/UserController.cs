using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.Dtos;
using Service.Implementation;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        private readonly IConfiguration _configuration;

        public UserController(IUserService service, ILogger<UserController> logger, IConfiguration configuration)
        {
            _service = service;
            _logger = logger;
            _configuration = configuration;
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

            var user = await _service.AuthenticateAsync(loginDto.Email, loginDto.Password);

            if (user == null)
                return Unauthorized("Email ou senha inválidos");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("email", user.Email),
                new Claim("name", user.Name),
                new Claim("role", user.IsAdmin ? "admin" : "user"),
                new Claim("userId", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                token = tokenString,
                usuario = new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.IsAdmin
                }
            });
        }

        [HttpPost("{id}/lock")]
        public async Task<IActionResult> LockUser(int id)
        {
            await _service.LockUser(id);
            return Ok(new { message = $"Usuário {id} bloqueado com sucesso." });
        }

        [HttpPost("{id}/unlock")]
        public async Task<IActionResult> UnlockUser(int id)
        {
            await _service.UnlockUser(id);
            return Ok(new { message = $"Usuário {id} desbloqueado com sucesso." });
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers(string name)
        {
            var users = await _service.SearchUsersAsync(name);
            return Ok(users.Select(u => new {
                u.Id,
                Name = u.Name,   
                u.Email,
                u.IsAdmin,
                u.IsBlocked
            }));
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userId = int.Parse(User.FindFirst("userId")!.Value);
            var user = await _service.GetById(userId);
            return Ok(user);
        }

        [HttpPut("me")]
        [Authorize]
        public async Task<IActionResult> UpdateMe(UserUpdateDto dto)
        {
            var userId = int.Parse(User.FindFirst("userId")!.Value);
            await _service.UpdateProfile(userId, dto);
            return NoContent();
        }

    }
}
