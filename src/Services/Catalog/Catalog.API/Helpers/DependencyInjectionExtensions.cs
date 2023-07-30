using Catalog.API.Data;
using Catalog.API.Decorators;
using Catalog.API.Repositories;

namespace Catalog.API.Helpers
{
    public static class DependencyInjectionExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductRepository, ProductRepositoryDecorator>();
        }

        public static void AddContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICatalogContext, CatalogContext>();
        }
    }
}
