using Basket.API.Decorators;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Basket.API.Services;

namespace Basket.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IBasketRepository, BasketRepositoryDecorator>();
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IBasketService, BasketService>();
        }

        public static IServiceCollection AddGrpcServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<DiscountGrpcService>();
        }
    }
}
