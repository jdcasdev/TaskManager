using MediatR;
using TaskManager.Application.Contracts.Repositories;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Response;
using TaskManager.Application.Queries.v1;

namespace TaskManager.Application.EventHandlers.v1.Queries
{
    public class GetTasksQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTasksQuery, Response<IEnumerable<TaskResDto>>>
    {
        public async Task<Response<IEnumerable<TaskResDto>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await taskRepository.GetAllAsync(cancellationToken);

            // Aquí se podría simplificar con AutoMapper (es la que conozco)
            var data = tasks.Select(t => new TaskResDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                EventDateTime = t.EventDateTime
            });

            return new Response<IEnumerable<TaskResDto>>
            {
                Success = true,
                Data = data
            };
        }
    }
}
