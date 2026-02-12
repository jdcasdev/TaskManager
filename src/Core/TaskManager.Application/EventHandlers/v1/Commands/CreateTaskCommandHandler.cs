using MediatR;
using TaskManager.Application.Commands.v1;
using TaskManager.Application.Contracts.Repositories;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Response;
using TaskManager.Domain;

namespace TaskManager.Application.EventHandlers.v1.Commands
{
    public class CreateTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<CreateTaskCommand, Response<TaskResDto>>
    {
        public async Task<Response<TaskResDto>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            // Aquí se podría simplificar con AutoMapper
            var taskItem = new TaskItem
            {
                Title = request.Payload.Title,
                Description = request.Payload.Description,
                Status = request.Payload.Status,
                EventDateTime = DateTime.UtcNow
            };

            var createdTask = await taskRepository.CreateAsync(taskItem, cancellationToken);

            // Aquí se podría simplificar con AutoMapper
            var data = new TaskResDto
            {
                Id = createdTask.Id,
                Title = createdTask.Title,
                Description = createdTask.Description,
                Status = createdTask.Status,
                EventDateTime = createdTask.EventDateTime
            };

            return new Response<TaskResDto>()
            {
                Success = true,
                Data = data
            };
        }
    }
}
