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

        public async Task<TaskItem?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TaskItem>.Filter.Eq(t => t.Id, id);
            return await context.Tasks.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TaskItem> CreateAsync(TaskItem taskItem, CancellationToken cancellationToken = default)
        {
            await context.Tasks.InsertOneAsync(taskItem, null, cancellationToken);
            return taskItem;
        }

        public async Task UpdateAsync(TaskItem taskItem, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TaskItem>.Filter.Eq(t => t.Id, taskItem.Id);
            await context.Tasks.ReplaceOneAsync(filter, taskItem, options: null as ReplaceOptions, cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TaskItem>.Filter.Eq(t => t.Id, id);
            await context.Tasks.DeleteOneAsync(filter, cancellationToken);
        }
    }
}
