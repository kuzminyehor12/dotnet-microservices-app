using Basket.API.Entities;
using Basket.API.Exceptions;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;

        public BasketRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task DeleteBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await GetBasketAsync(userName, cancellationToken);

            if (basket.IsEmpty)
            {
                throw new BasketException($"There are no basket for username = {userName}");
            }

            await _distributedCache.RemoveAsync(userName, cancellationToken);
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await _distributedCache.GetStringAsync(userName, cancellationToken);

            if (string.IsNullOrEmpty(basket))
            {
                return ShoppingCart.Empty(userName);
            }

            return JsonSerializer.Deserialize<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            if (basket.IsEmpty)
            {
                return basket;
            }

            var json = JsonSerializer.Serialize(basket);
            await _distributedCache.SetStringAsync(basket.UserName, json, cancellationToken);
            return await GetBasketAsync(basket.UserName, cancellationToken);
        }
    }
}
