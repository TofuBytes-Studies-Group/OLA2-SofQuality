using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using OLA2_SofQuality;
using System.Collections.Generic;
using OLA2_SofQuality.Models;
using Newtonsoft.Json;
using System.IO;

namespace API_Integation_test
{
    public class TasksControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TasksControllerTest(WebApplicationFactory<Program> factory)
        {
            // Set the content root to the correct directory
            factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\OLA2-SofQuality"));
            });

            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetTasks_ReturnsListOfTasks()
        {
            // Act
            var response = await _client.GetAsync("/api/task");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<ToDoTask>>(responseString);
            Assert.NotNull(tasks);
            Assert.NotEmpty(tasks);
        }
    }
}