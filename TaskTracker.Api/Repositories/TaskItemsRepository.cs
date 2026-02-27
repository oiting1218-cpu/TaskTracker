using Microsoft.EntityFrameworkCore;
using TaskTracker.Api.Data;
using TaskTracker.Api.DTOs;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Repositories
{
    public class TaskItemsRepository : ITaskItemsRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskItemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> GetTaskItemById(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItems()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task AddTaskItem(TaskItem task)
        {
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskItem(TaskItem task, UpdateTaskDTO dto)
        {
            task.Title = dto.Title;
            task.Status = dto.Status;
            if (dto.Description != null)
                task.Description = dto.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskItem(TaskItem task)
        {
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
