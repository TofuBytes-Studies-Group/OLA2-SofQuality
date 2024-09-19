using System;
using Xunit;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using OLA2_SofQuality.Data;
using OLA2_SofQuality.Models;
using OLA2_SofQuality.Repositories;


namespace OLA2_SofQuality.Tests.Repositories_Test;

public class RepositoriesTest : IDisposable
{
    private readonly TaskRepository _taskRepository;
    private readonly SQLiteConnection _connection;

    public RepositoriesTest()
    {
        var connectionString = "Data Source=:memory:;Version=3;New=True;";
        _connection = new SQLiteConnection(connectionString);
        _connection.Open();
        InitializeDatabase();

        var options = new DbContextOptionsBuilder<ToDoListContext>()
            .UseSqlite(_connection)
            .Options;

        _taskRepository = new TaskRepository(new ToDoListContext(options));
    }

    private void InitializeDatabase()
    {
        using (var command = new SQLiteCommand(
                   "CREATE TABLE IF NOT EXISTS ToDoTasks (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                   "Description TEXT NOT NULL, " +
                   "Category TEXT NOT NULL, " +
                   "Deadline DATETIME NOT NULL, " +
                   "IsCompleted BOOLEAN NOT NULL)", _connection))
        {
            command.ExecuteNonQuery();
        }

        // Log table creation
        using (var command =
               new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='ToDoTasks';",
                   _connection))
        {
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Table 'ToDoTasks' created successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to create table 'ToDoTasks'.");
                }
            }
        }
    }

    [Fact]
    public async Task AddTask_TaskIsAdded()
    {
        var task = new ToDoTask()
        {
            Description = "Test Task",
            Category = "Test Category",
            Deadline = DateTime.Now.AddDays(1),
            IsCompleted = false
        };

        await _taskRepository.AddTaskAsync(task);

        var tasks = await _taskRepository.GetTasksAsync();
        Assert.Single(tasks);
        Assert.Equal("Test Task", tasks[0].Description);
    }

    [Fact]
    public async Task UpdateTask_TaskIsUpdated()
    {
        var task = new ToDoTask()
        {
            Description = "Test Task",
            Category = "Test Category",
            Deadline = DateTime.Now.AddDays(1),
            IsCompleted = false
        };

        var addedTask = await _taskRepository.AddTaskAsync(task);


        var expactedToDoTask = new ToDoTask()
        {
            Id = addedTask.Id,
            Description = "Updated Task",
            Category = "Updated Category",
            Deadline = DateTime.Now.AddDays(2),
            IsCompleted = true
        };

        var updatedTask = await _taskRepository.UpdateTaskAsync(addedTask.Id, expactedToDoTask);

        Assert.Equal(expactedToDoTask.Id, updatedTask.Id);
        Assert.Equal(expactedToDoTask.Description, updatedTask.Description);
        Assert.Equal(expactedToDoTask.Category, updatedTask.Category);
        Assert.Equal(expactedToDoTask.Deadline, updatedTask.Deadline);
        Assert.Equal(expactedToDoTask.IsCompleted, updatedTask.IsCompleted);
    }

    [Fact]
    public async Task DeleteTask_TaskIsDeleted()
    {
        var task = new ToDoTask
        {
            Description = "Test Task",
            Category = "Test Category",
            Deadline = DateTime.Now.AddDays(1),
            IsCompleted = false
        };

        await _taskRepository.AddTaskAsync(task);
        var tasks = await _taskRepository.GetTasksAsync();
        var taskId = tasks[0].Id;

        await _taskRepository.DeleteTaskAsync(taskId);

        tasks = await _taskRepository.GetTasksAsync();
        Assert.Empty(tasks);
    }

    [Fact]
    public async Task MarkTaskAsCompleted_TaskIsMarkedAsCompleted()
    {
        var task = new ToDoTask
        {
            Description = "Test Task",
            Category = "Test Category",
            Deadline = DateTime.Now.AddDays(1),
            IsCompleted = false
        };

        await _taskRepository.AddTaskAsync(task);
        var tasks = await _taskRepository.GetTasksAsync();
        var taskId = tasks[0].Id;

        task.IsCompleted = true;
        await _taskRepository.UpdateTaskAsync(taskId, task);

        tasks = await _taskRepository.GetTasksAsync();
        Assert.Single(tasks);
        Assert.True(tasks[0].IsCompleted);
    }

    [Fact]
    public async Task GetTasks_ReturnsAllTasks()
    {
        var task1 = new ToDoTask
        {
            Description = "Test Task 1",
            Category = "Test Category 1",
            Deadline = DateTime.Now.AddDays(1),
            IsCompleted = false
        };

        var task2 = new ToDoTask
        {
            Description = "Test Task 2",
            Category = "Test Category 2",
            Deadline = DateTime.Now.AddDays(2),
            IsCompleted = true
        };

        await _taskRepository.AddTaskAsync(task1);
        await _taskRepository.AddTaskAsync(task2);

        var tasks = await _taskRepository.GetTasksAsync();
        Assert.Equal(2, tasks.Count);
    }

    public void Dispose()
    {
        using (var command = new SQLiteCommand("DROP TABLE IF EXISTS TasksTest", _connection))
        {
            command.ExecuteNonQuery();
        }

        _connection.Close();
    }
}