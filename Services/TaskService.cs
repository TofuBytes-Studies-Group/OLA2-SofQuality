using OLA2_SofQuality.Models;
using OLA2_SofQuality.Repositories;

namespace OLA2_SofQuality.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<ToDoTask>> GetTasksAsync()
        {
            return await _taskRepository.GetTasksAsync();
        }

        public async Task<ToDoTask> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task<ToDoTask> AddTaskAsync(ToDoTask task)
        {
            var addedTask = await _taskRepository.AddTaskAsync(task);
            return addedTask;
        }

        public async Task<ToDoTask> UpdateTaskAsync(ToDoTask task)
        {
            var updateObject = await _taskRepository.UpdateTaskAsync(task);
            return updateObject;
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
        }
    }
} 