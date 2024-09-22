
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using OLA2_SofQuality.Controllers;
using OLA2_SofQuality.Models;
using OLA2_SofQuality.Services;
using Xunit;

namespace API_Integration_test;

public class TasksControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly Mock<ITaskService> _mockTaskService;
    private readonly TasksController _controller;

    public TasksControllerTest(WebApplicationFactory<Program> factory)
    {
        // Set the content root to the correct directory
        factory = factory.WithWebHostBuilder(builder =>
        {
            builder.UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(),
                @"..\..\..\..\OLA2-SofQuality"));
        });

        factory.CreateClient();
        _mockTaskService = new Mock<ITaskService>();
        _controller = new TasksController(_mockTaskService.Object);
    }

    [Fact]
    public async Task GetTasks_ReturnsListOfTasks()
    {
        // Arrange
        var mockTasks = new List<ToDoTask>
        {
            new()
            {
                Id = 1, Description = "Description 1", Category = "Category 1", IsCompleted = false,
                Deadline = new DateTime()
            },
            new()
            {
                Id = 2, Description = "Description 2", Category = "Category 2", IsCompleted = true,
                Deadline = new DateTime()
            }
        };
        _mockTaskService.Setup(service => service.GetTasksAsync()).ReturnsAsync(mockTasks);

        // Act
        var result = await _controller.GetTasks();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnTasks = Assert.IsType<List<ToDoTask>>(okResult.Value);
        Assert.Equal(2, returnTasks.Count);
    }

    [Fact]
    public async Task GetTask_ReturnsTaskById()
    {
        // Arrange
        var mockTask = new ToDoTask
        {
            Id = 1, Description = "Description 1", Category = "Category 1", IsCompleted = false,
            Deadline = new DateTime()
        };
        _mockTaskService.Setup(service => service.GetTaskByIdAsync(1)).ReturnsAsync(mockTask);

        // Act
        var result = await _controller.GetTask(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnTask = Assert.IsType<ToDoTask>(okResult.Value);
        Assert.Equal(1, returnTask.Id);
    }

    [Fact]
    public async Task AddTask_ReturnsCreatedTask()
    {
        // Arrange
        var newTask = new ToDoTask
        {
            Id = 1, Description = "Description 1", Category = "Category 1", IsCompleted = false,
            Deadline = new DateTime()
        };
        _mockTaskService.Setup(service => service.AddTaskAsync(newTask)).ReturnsAsync(newTask);

        // Act
        var result = await _controller.AddTask(newTask);

        // Assert
        var createdResult = Assert.IsType<CreatedResult>(result);
        var returnTask = Assert.IsType<ToDoTask>(createdResult.Value);
        Assert.Equal(1, returnTask.Id);
    }

    [Fact]
    public async Task UpdateTask_ReturnsUpdatedTask()
    {
        // Arrange
        var updatedTask = new ToDoTask
        {
            Id = 1, Description = "Updated Description", Category = "Updated Category", IsCompleted = true,
            Deadline = new DateTime()
        };
        _mockTaskService.Setup(service => service.UpdateTaskAsync(1, updatedTask)).ReturnsAsync(updatedTask);

        // Act
        var result = await _controller.UpdateTask(1, updatedTask);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnTask = Assert.IsType<ToDoTask>(okResult.Value);
        Assert.Equal("Updated Description", returnTask.Description);
        Assert.Equal("Updated Category", returnTask.Category);
        Assert.True(returnTask.IsCompleted);
        Assert.Equal(new DateTime(), returnTask.Deadline);
    }

    [Fact]
    public async Task DeleteTask_ReturnsNoContent()
    {
        // Arrange
        _mockTaskService.Setup(service => service.DeleteTaskAsync(1)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteTask(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
        
    [Fact]
    public async Task GetTask_ReturnNotFound()
    {
        // Arrange
        var mockTask = new ToDoTask
        {
            Id = 1, Description = "Description 1", Category = "Category 1", IsCompleted = false,
            Deadline = new DateTime()
        };
        _mockTaskService.Setup(service => service.GetTaskByIdAsync(1)).ReturnsAsync(mockTask);

        // Act
        var result = await _controller.GetTask(2);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
        
    }
}