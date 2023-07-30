using Catalog.API.Configuration;
using Catalog.API.Entities;
using Catalog.API.Helpers;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoCollection<Product> _products;

        public CatalogContext(DatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _products = database.GetCollection<Product>(databaseSettings.CollectionName);
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                _products.Seed();
                return _products;
            }
        }
    }
}
