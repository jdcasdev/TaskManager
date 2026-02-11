using MongoDB.Driver;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Contracts.Repositories;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository(IMongoDbContext context) : ITaskRepository
    {
        // Primera vez haciendo consultas también con MongoDb.
        // Extracción base de CRUD: https://www.youtube.com/watch?v=Gxf7zBl5Z64
        public async Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Tasks.Find(FilterDefinition<TaskItem>.Empty).ToListAsync(cancellationToken);
        }
    }
}
