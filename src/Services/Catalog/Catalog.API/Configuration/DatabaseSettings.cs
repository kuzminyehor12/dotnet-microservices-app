namespace Catalog.API.Configuration
{
    public class DatabaseSettings
    {
        public DatabaseSettings(IConfiguration configuration)
        {
            ConnectionString = configuration[string.Join(':', nameof(DatabaseSettings), nameof(ConnectionString))];
            DatabaseName = configuration[string.Join(':', nameof(DatabaseSettings), nameof(DatabaseName))];
            CollectionName = configuration[string.Join(':', nameof(DatabaseSettings), nameof(CollectionName))];
        }
        public string ConnectionString { get; }

        public string DatabaseName { get; }

        public string CollectionName { get; }
    }
}
