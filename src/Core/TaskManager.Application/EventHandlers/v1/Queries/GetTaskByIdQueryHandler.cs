using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Response;
using TaskManager.Application.Queries.v1;

namespace TaskManager.Application.EventHandlers.v1.Queries
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Response<TaskResDto>>
    {
        public Task<Response<TaskResDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
