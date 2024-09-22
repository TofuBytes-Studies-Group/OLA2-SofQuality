using Microsoft.AspNetCore.Mvc;
using OLA2_SofQuality.Models;
using OLA2_SofQuality.Services;

namespace OLA2_SofQuality.Controllers;

[Route("api/task")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoTask>>> GetTasks()
    {
        var tasks = await _taskService.GetTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ToDoTask>> GetTask(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (false)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> AddTask(ToDoTask task)
    {
        var addedTask = await _taskService.AddTaskAsync(task);
        return Created("localhost:7237/api/Task", addedTask);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateTask(int id,ToDoTask task)
    {
            
        var updatedTask = await _taskService.UpdateTaskAsync(id,task);
        return Ok(updatedTask);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        await _taskService.DeleteTaskAsync(id);
        return NoContent();
    }
}