using MediatR;
using TaskManager.Application.Commands.v1;
using TaskManager.Application.Contracts.Repositories;

namespace TaskManager.Application.EventHandlers.v1.Commands
{
    public class DeleteTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<DeleteTaskCommand>
    {
        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await taskRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
