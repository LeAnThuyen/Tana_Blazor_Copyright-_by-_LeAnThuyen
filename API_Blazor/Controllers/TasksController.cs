using API_Blazor.Entities;
using API_Blazor.Respositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace API_Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepositoty _taskRepositoty;
        public TasksController(ITaskRepositoty taskRepositoty)
        {
            _taskRepositoty = taskRepositoty;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TaskListSearch taskListSearch)
        {
            var task = await _taskRepositoty.GetTaskList(taskListSearch);
            var taskDto = task.Select(c => new TaskDTO()
            {
                Status = c.Status,
                Name = c.Name,
                AssigneeId = c.AssigneeId,
                Created = c.Created,
                Priority = c.Priority,
                Id = c.Id,
                AssigneeName = c.Assignee != null ? c.Assignee.FirstName + " " + c.Assignee.LastName : "N/A"
            });
            return Ok(taskDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateRequest taskCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var tasker = await _taskRepositoty.CreateTask(new Entities.Task()
            {
                Name = taskCreate.Name,
                Priority = taskCreate.Priority.HasValue ? taskCreate.Priority.Value : Priority.High,
                Status = Status.New,
                Id = taskCreate.Id
            });
            return CreatedAtAction(nameof(GetById), new { id = tasker.Id }, tasker);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _taskRepositoty.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Entities.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var tasks = await _taskRepositoty.GetById(id);
            if (tasks == null)
            {
                return NotFound();
            }
            await _taskRepositoty.UpdateTask(task);
            return Ok(task);
        }
    }
}
