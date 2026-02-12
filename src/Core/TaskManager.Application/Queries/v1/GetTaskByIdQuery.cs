using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Response;

namespace TaskManager.Application.Queries.v1
{
    public class GetTaskByIdQuery(string id) : IRequest<Response<TaskResDto>>
    {
        public string Id { get; set; } = id;
    }
}
