using MediatR;
using TaskManager.Application.Contracts.Repositories;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Response;
using TaskManager.Application.Queries.v1;

namespace TaskManager.Application.EventHandlers.v1.Queries
{
    public class GetTaskByIdQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTaskByIdQuery, Response<TaskResDto>>
    {
        public async Task<Response<TaskResDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await taskRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new KeyNotFoundException("No se encontró la tarea solicitada.");

            // Aquí se podría simplificar con AutoMapper
            var data = new TaskResDto()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                EventDateTime = task.EventDateTime
            };

            return new Response<TaskResDto>()
            {
                Success = true,
                Data = data
            };
        }
    }
}
