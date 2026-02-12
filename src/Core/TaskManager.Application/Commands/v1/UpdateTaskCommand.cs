using MediatR;
using TaskManager.Application.DTOs.v1.Request;

namespace TaskManager.Application.Commands.v1
{
    public class UpdateTaskCommand(string id, UpdateTaskReqDto payload) : IRequest
    {
        public string Id { get; set; } = id;
        public UpdateTaskReqDto Payload { get; set; } = payload;
    }
}
