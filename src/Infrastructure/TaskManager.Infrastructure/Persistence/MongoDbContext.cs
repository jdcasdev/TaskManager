using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Persistence
{
    public class MongoDbContext : IMongoDbContext
    {
        public MongoDbContext(IMongoDatabase database, IOptions<MongoDbSettings> settings)
        {
            var mongoSettings = settings.Value;
            Tasks = database.GetCollection<TaskItem>(mongoSettings.TasksCollectionName);
        }

        public IMongoCollection<TaskItem> Tasks { get; }
    }
}
