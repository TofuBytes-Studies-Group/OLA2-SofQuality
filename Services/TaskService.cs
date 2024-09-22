using OLA2_SofQuality.Models;
using OLA2_SofQuality.Repositories;

namespace OLA2_SofQuality.Services;

public class TaskService(ITaskRepository taskRepository) : ITaskService
{
    public async Task<List<ToDoTask>> GetTasksAsync()
    {
        return await taskRepository.GetTasksAsync();
    }

    public async Task<ToDoTask> GetTaskByIdAsync(int id)
    {
        return await taskRepository.GetTaskByIdAsync(id);
    }

    public async Task<ToDoTask> AddTaskAsync(ToDoTask task)
    {
        var addedTask = await taskRepository.AddTaskAsync(task);
        return addedTask;
    }

    public async Task<ToDoTask> UpdateTaskAsync(int id, ToDoTask task)
    {
        var updateObject = await taskRepository.UpdateTaskAsync(id, task);
        return updateObject;
    }

    public async Task DeleteTaskAsync(int id)
    {
        await taskRepository.DeleteTaskAsync(id);
    }
}