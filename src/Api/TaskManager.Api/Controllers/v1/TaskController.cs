using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.v1;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Request;
using TaskManager.Application.DTOs.v1.Response;
using TaskManager.Application.Queries.v1;

namespace TaskManager.Api.Controllers.v1
{
    [ApiController]
    [Route("api/tasks")]
    [Tags("Tasks Controller")]
    public class TaskController : BaseApiController
    {
        [HttpGet]
        public async Task<Response<IEnumerable<TaskResDto>>> GetTasks()
        {
            return await _mediator.Send(new GetTasksQuery());
        }

        [HttpGet("{id:int}")]
        public async Task<Response<TaskResDto>> GetTaskById(int id)
        {
            return await _mediator.Send(new GetTaskByIdQuery(id));
        }

        [HttpPost]
        public async Task<Response<TaskResDto>> CreateTask(CreateTaskReqDto payload)
        {
            return await _mediator.Send(new CreateTaskCommand(payload));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTask(int id)
        {
            await _mediator.Send(new UpdateTaskCommand(id));
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));
            return NoContent();
        }
    }
}
