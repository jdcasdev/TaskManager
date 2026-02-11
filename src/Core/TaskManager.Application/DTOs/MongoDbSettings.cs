namespace TaskManager.Application.DTOs
{
    public class MongoDbSettings
    {
        public const string SectionName = "Mongo";

        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
        public required string TasksCollectionName { get; set; }
    }
}
