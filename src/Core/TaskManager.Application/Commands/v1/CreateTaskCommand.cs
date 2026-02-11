using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Request;
using TaskManager.Application.DTOs.v1.Response;

namespace TaskManager.Application.Commands.v1
{
    public class CreateTaskCommand(CreateTaskReqDto payload) : IRequest<Response<TaskResDto>>
    {
        public CreateTaskReqDto Payload { get; set; } = payload;
    }
}
