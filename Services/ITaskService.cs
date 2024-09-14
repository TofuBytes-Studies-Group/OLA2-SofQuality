using OLA2_SofQuality.Models;

namespace OLA2_SofQuality.Services
{
    public interface ITaskService
    {
        Task<List<ToDoTask>> GetTasksAsync();
        Task<ToDoTask> GetTaskByIdAsync(int id);
        Task <ToDoTask> AddTaskAsync(ToDoTask task);
        Task<ToDoTask> UpdateTaskAsync(int id, ToDoTask task);
        Task DeleteTaskAsync(int id);
    }
}