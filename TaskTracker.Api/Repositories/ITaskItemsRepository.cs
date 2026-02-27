using TaskTracker.Api.DTOs;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Repositories
{
    public interface ITaskItemsRepository
    {
        Task<TaskItem?> GetTaskItemById(int id);

        Task<IEnumerable<TaskItem>> GetTaskItems();

        Task AddTaskItem(TaskItem task);

        Task UpdateTaskItem(TaskItem task, UpdateTaskDTO dto);

        Task DeleteTaskItem(TaskItem task);
    }
}
