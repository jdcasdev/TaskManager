using MediatR;
using TaskManager.Application.Commands.v1;

namespace TaskManager.Application.EventHandlers.v1.Commands
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        public Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
