using MediatR;
using TaskManager.Application.Commands.v1;
using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.v1.Response;

namespace TaskManager.Application.EventHandlers.v1.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Response<TaskResDto>>
    {
        public Task<Response<TaskResDto>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
