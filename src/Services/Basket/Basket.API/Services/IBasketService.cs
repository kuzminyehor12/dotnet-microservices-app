using Basket.API.Entities;

namespace Basket.API.Services
{
    public interface IBasketService
    {
        Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default);

        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default);

        Task DeleteBasketAsync(string userName, CancellationToken cancellationToken = default);
    }
}
