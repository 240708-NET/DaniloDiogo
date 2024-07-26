using Microsoft.AspNetCore.Mvc;
using ToDoList.Repository;
using ToDoList.Models;

namespace ToDoList.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskItem> logger;

    private ITaskRepository repository;

    public TaskController(ILogger<TaskItem> logger, ITaskRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet]
    public List<TaskItem> GetAllTasks()
    {
        return this.repository.list();
    }

    [HttpGet("{id}")]
    public TaskItem GetTaskById( int id )
    {
        return this.repository.getById(id);
    }

    [HttpPut]
    public bool Update(TaskItem taskItem)
    {
        try
        {
            this.repository.update(taskItem);
            return true;
        }
        catch (System.Exception)
        {

            return false;
        }
        
    }

    [HttpPost]
    public TaskItem Insert( [FromBody] TaskItem newTask )
    {
        try
        {
            this.repository.save(newTask);
            var tasks = this.repository.list();

            return tasks.OrderByDescending(t => t.Id).FirstOrDefault();
        }
        catch
        {
            return new TaskItem();
        }
    }

    [HttpDelete("{id}")]
    public bool DeleteTask( int id )
    {
        try
        {
            this.repository.deleteById( id );
            return true;
        }
        catch
        {
            return false;
        }
    }
}
