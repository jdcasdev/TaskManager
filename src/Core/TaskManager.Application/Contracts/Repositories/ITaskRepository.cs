using TaskManager.Domain;

namespace TaskManager.Application.Contracts.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TaskItem?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<TaskItem> CreateAsync(TaskItem taskItem, CancellationToken cancellationToken = default);
        Task UpdateAsync(TaskItem taskItem, CancellationToken cancellationToken = default);
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
    }
}
