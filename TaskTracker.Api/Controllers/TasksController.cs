using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Api.Data;
using TaskTracker.Api.Models;
using TaskTracker.Api.DTOs;
using TaskTracker.Api.Services;

namespace TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService) 
        {
            _taskService = taskService;
        }
                
        [HttpPost]
        public async Task<IActionResult> AddTask(CreateTaskDto dto)
        {
            var task = await _taskService.AddTaskAsync(dto);
            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks() 
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDTO dto)
        {
            var updated = await _taskService.UpdateTaskAsync(id, dto);
            
            if (!updated)
                return NotFound();
            else
                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteTaskAsync(id);
            
            if(!deleted)
                return NotFound();
            else
                return NoContent();
        }
    }
}
