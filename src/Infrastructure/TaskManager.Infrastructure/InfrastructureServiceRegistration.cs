using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Contracts.Repositories;
using TaskManager.Application.DTOs;
using TaskManager.Infrastructure.Persistence;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Primera vez implementado MongoDb (lo podía hacer en memoría pero quería probar)
            // https://www.mongodb.com/docs/drivers/csharp/current/databases-collections/
            services.Configure<MongoDbSettings>(configuration.GetSection(MongoDbSettings.SectionName));
            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });
            services.AddScoped(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DatabaseName);
            });

            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
