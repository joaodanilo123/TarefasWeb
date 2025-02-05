using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasWeb.Data;
using TarefasWeb.DTO;
using TarefasWeb.Models;

namespace TarefasWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users.Select(u => u.ToUserDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] NewUserDTO dto)
        {
            var user = new User()
            {
                Name = dto.Name,
                Password = dto.Password,
                Username = dto.Username,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new {id = user.Id}, user);
        }
    }

}