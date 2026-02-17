using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Api.Data;
using TaskTracker.Api.Models;
using TaskTracker.Api.DTOs;

namespace TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context) 
        {
            _context = context;
        }
                
        [HttpPost]
        public async Task<IActionResult> AddTask(CreateTaskDto dto)
        {
            var task = new TaskItem { 
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                CreatedAt = DateTime.UtcNow
            };
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks() 
        {
            var tasks = await _context.TaskItems.ToListAsync();
            return Ok(tasks);
        }

    }
}
