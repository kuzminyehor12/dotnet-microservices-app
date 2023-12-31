﻿using Discount.DataAccess.Decorators;
using Discount.DataAccess.Repositories;
using Npgsql;

namespace Discount.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDiscountDbConnection(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection.AddTransient(serviceProvider =>
            {
                return new NpgsqlConnection(configuration["ConnectionStrings:Postgres"]);
            });
        }

        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IDiscountRepository, DiscountRepositoryDecorator>();
        }
    }
}
