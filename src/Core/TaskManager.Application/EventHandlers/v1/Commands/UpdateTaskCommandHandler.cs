using MediatR;
using TaskManager.Application.Commands.v1;
using TaskManager.Application.Contracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Application.EventHandlers.v1.Commands
{
    public class UpdateTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<UpdateTaskCommand>
    {
        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await taskRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new KeyNotFoundException("No se encontró la tarea solicitada.");

            TaskStatusNormalized.TryNormalize(request.Payload.Status, out var normalizedStatus);

            task.Title = request.Payload.Title;
            task.Description = request.Payload.Description;
            task.Status = normalizedStatus;
            task.EventDateTime = request.Payload.EventDateTime == default ? DateTime.UtcNow : request.Payload.EventDateTime;

            await taskRepository.UpdateAsync(task, cancellationToken);
        }
    }
}
