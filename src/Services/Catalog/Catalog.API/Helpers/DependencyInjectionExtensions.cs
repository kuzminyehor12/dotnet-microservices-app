using Catalog.API.Configuration;
using Catalog.API.Data;
using Catalog.API.Decorators;
using Catalog.API.Repositories;

namespace Catalog.API.Helpers
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IProductRepository, ProductRepositoryDecorator>();
        }

        public static IServiceCollection AddContext(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<ICatalogContext, CatalogContext>();
        }

        public static IServiceCollection AddDbSettings(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection.AddSingleton(serviceProvider =>
            {
                return new DatabaseSettings(configuration);
            });
        }
    }
}
