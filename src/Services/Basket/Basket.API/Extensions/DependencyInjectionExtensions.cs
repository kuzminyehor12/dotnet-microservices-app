using Basket.API.Decorators;
using Basket.API.Repositories;

namespace Basket.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IBasketRepository, BasketRepositoryDecorator>();
        }
    }
}
