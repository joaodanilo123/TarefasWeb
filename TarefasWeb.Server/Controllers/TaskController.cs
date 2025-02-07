using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasWeb.Data;
using TarefasWeb.DTO;
using TarefasWeb.Models;

namespace TarefasWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {

        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        { 
            _context = context;
        }   

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListTasks()
        {
            var userId = User.FindFirst("UserId")?.Value;

            if (userId == null)
                return Unauthorized();

            var tasks = await _context.Tasks
                .Where(t => t.UserId == int.Parse(userId))
                .ToListAsync();

            return Ok(tasks.Select(t => t.ToTaskDTO()));
        }

        [HttpPost("adicionar")]
        [Authorize]
        public async Task<IActionResult> CreateTask([FromBody] NewTaskDTO dto)
        {
            var userId = User.FindFirst("UserId")?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            var user = await _context.Users.FindAsync(int.Parse(userId));
            
            if (user == null)
            {
                return Unauthorized();
            }
            
            var newTask = new Models.Task()
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = Models.TaskStatus.PENDING,
                CreatedAt = DateTime.Now,
                User = user,
                UserId = user.Id
            };

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            return Ok("Tarefa cadastrada com sucesso");
        }

        [HttpPost("{id}/concluir")]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] Models.TaskStatus status)
        {

            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            if (status == Models.TaskStatus.COMPLETED) {
                task.CompletedAt = DateTime.Now;
            }

            task.Status = status;

            await _context.SaveChangesAsync();

            return Ok("Tarefa marcada como concluída");
        }

        [HttpPost("{id}/excluir")]
        [Authorize]
        public async Task<IActionResult> ExcluirTarefa(int id)
        {

            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return Ok("Tarefa excluída com sucesso");
        }
    }
}