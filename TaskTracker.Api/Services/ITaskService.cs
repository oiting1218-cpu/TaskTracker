using TaskTracker.Api.DTOs;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetTasksAsync();

        Task<TaskItem?> GetTaskByIdAsync(int id);

        Task<TaskItem> AddTaskAsync(CreateTaskDto dto);

        Task<bool> UpdateTaskAsync(int id, UpdateTaskDTO dto);

        Task<bool> DeleteTaskAsync(int id);

    }
}
