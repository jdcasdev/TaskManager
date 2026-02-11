using TaskManager.Domain;

namespace TaskManager.Application.Contracts.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
