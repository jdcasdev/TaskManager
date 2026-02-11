using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Response;

namespace TaskManager.Application.Queries.v1
{
    public class GetTasksQuery : IRequest<Response<IEnumerable<TaskResDto>>>
    {
    }
}
