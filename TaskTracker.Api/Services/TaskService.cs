using Microsoft.EntityFrameworkCore;
using TaskTracker.Api.DTOs;
using TaskTracker.Api.Models;
using TaskTracker.Api.Repositories;

namespace TaskTracker.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskItemsRepository _taskRepository;
        public TaskService(ITaskItemsRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            return await _taskRepository.GetTaskItems();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetTaskItemById(id);
        }

        public async Task<TaskItem> AddTaskAsync(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                CreatedAt = DateTime.UtcNow
            };
            await _taskRepository.AddTaskItem(task);
            return task;
        }

        public async Task<bool> UpdateTaskAsync(int id, UpdateTaskDTO dto)
        {
            var task = await _taskRepository.GetTaskItemById(id);

            if (task == null)
                return false;

            await _taskRepository.UpdateTaskItem(task, dto);

            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _taskRepository.GetTaskItemById(id);

            if (task == null)
                return false;

            await _taskRepository.DeleteTaskItem(task);
            return true;
        }
    }
}
