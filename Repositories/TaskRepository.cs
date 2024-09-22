using Microsoft.EntityFrameworkCore;
using OLA2_SofQuality.Data;
using OLA2_SofQuality.Models;

namespace OLA2_SofQuality.Repositories;

public class TaskRepository(ToDoListContext context) : ITaskRepository
{
    public async Task<List<ToDoTask>> GetTasksAsync()
    {
        return await context.ToDoTasks.Select(t => new ToDoTask
        {
            Id = t.Id,
            Description = t.Description,
            Category = t.Category,
            Deadline = t.Deadline,
            IsCompleted = t.IsCompleted
        }).ToListAsync<ToDoTask>();
    }

    public async Task<ToDoTask> GetTaskByIdAsync(int id)
    {
        var task = await context.ToDoTasks.FindAsync(id);
        if (task == null) throw new Exception("Task not found");

        return new ToDoTask
        {
            Id = task.Id,
            Description = task.Description,
            Category = task.Category,
            Deadline = task.Deadline,
            IsCompleted = task.IsCompleted
        };
    }

    public async Task<ToDoTask> AddTaskAsync(ToDoTask task)
    {
        var response = await context.ToDoTasks.AddAsync(task);
        await context.SaveChangesAsync();
        return new ToDoTask
        {
            Id = response.Entity.Id,
            Description = response.Entity.Description,
            Category = response.Entity.Category,
            Deadline = response.Entity.Deadline,
            IsCompleted = response.Entity.IsCompleted
        };
    }

    public async Task<ToDoTask> UpdateTaskAsync(int id, ToDoTask task)
    {
        var entity = await context.ToDoTasks.FindAsync(id);
        if (entity == null) throw new Exception("Task not found");

        entity.Description = task.Description;
        entity.Category = task.Category;
        entity.Deadline = task.Deadline;
        entity.IsCompleted = task.IsCompleted;

            
        var response = context.ToDoTasks.Update(entity);
        await context.SaveChangesAsync();
        return response.Entity;
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await context.ToDoTasks.FindAsync(id);
        if (task == null) throw new Exception("Task not found");
            
        context.ToDoTasks.Remove(task);
        await context.SaveChangesAsync();
    }
}