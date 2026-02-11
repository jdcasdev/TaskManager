using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Response;
using TaskManager.Application.Queries.v1;

namespace TaskManager.Application.EventHandlers.v1.Queries
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, Response<IEnumerable<TaskResDto>>>
    {
        public Task<Response<IEnumerable<TaskResDto>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
