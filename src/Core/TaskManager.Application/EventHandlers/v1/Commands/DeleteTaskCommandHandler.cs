using MediatR;
using TaskManager.Application.Commands.v1;

namespace TaskManager.Application.EventHandlers.v1.Commands
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        public Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
