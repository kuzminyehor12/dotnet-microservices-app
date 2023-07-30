using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Decorators
{
    public class BasketRepositoryDecorator : IBasketRepository
    {
        private readonly BasketRepository _basketRepository;
        private readonly ILogger<BasketRepositoryDecorator> _logger;

        public BasketRepositoryDecorator(
            IDistributedCache distributedCache, 
            ILogger<BasketRepositoryDecorator> logger)
        {
            _basketRepository = new BasketRepository(distributedCache);
            _logger = logger;
        }
        public async Task DeleteBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            try
            {
                await _basketRepository.DeleteBasketAsync(userName, cancellationToken);
                _logger.LogInformation("Basket has been deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            return _basketRepository.GetBasketAsync(userName, cancellationToken);
        }

        public Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            return _basketRepository.UpdateBasketAsync(basket, cancellationToken);
        }
    }
}
