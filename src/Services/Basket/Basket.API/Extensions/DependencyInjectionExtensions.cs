using Basket.API.Decorators;
using Basket.API.Repositories;

namespace Basket.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBasketRepository, BasketRepositoryDecorator>();
        }
    }
}
