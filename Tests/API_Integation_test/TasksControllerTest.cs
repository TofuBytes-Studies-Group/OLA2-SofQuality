using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using OLA2_SofQuality;
using OLA2_SofQuality.Controllers;
using OLA2_SofQuality.Models;
using OLA2_SofQuality.Services;
using Xunit;

namespace API_Integation_test
{
    public class TasksControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Mock<ITaskService> _mockTaskService;
        private readonly TasksController _controller;

        public TasksControllerTest(WebApplicationFactory<Program> factory)
        {
            // Set the content root to the correct directory
            factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\OLA2-SofQuality"));
            });

            _client = factory.CreateClient();
            _mockTaskService = new Mock<ITaskService>();
            _controller = new TasksController(_mockTaskService.Object);
        }

        [Fact]
        public async Task GetTasks_ReturnsListOfTasks()
        {
            // Arrange
            var mockTasks = new List<ToDoTask>
            {
                new ToDoTask { Id = 1, Description = "Description 1", Category = "Category 1", IsCompleted = false, Deadline = new DateTime() },
                new ToDoTask { Id = 2, Description = "Description 2", Category = "Category 2", IsCompleted = true, Deadline = new DateTime() }
            };
            _mockTaskService.Setup(service => service.GetTasksAsync()).ReturnsAsync(mockTasks);

            // Act
            var result = await _controller.GetTasks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnTasks = Assert.IsType<List<ToDoTask>>(okResult.Value);
            Assert.Equal(2, returnTasks.Count);
        }
    }
}