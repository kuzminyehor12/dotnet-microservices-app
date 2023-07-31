using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;

namespace Basket.API.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountGrpcService;

        public BasketService(
            IBasketRepository basketRepository, 
            DiscountGrpcService discountGrpcService)
        {
            _basketRepository = basketRepository;
            _discountGrpcService = discountGrpcService;
        }

        public Task DeleteBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            return _basketRepository.DeleteBasketAsync(userName, cancellationToken);
        }

        public Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            return _basketRepository.GetBasketAsync(userName, cancellationToken);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetDiscountAsync(item.ProductName);
                item.Price -= coupon.Amount;
            }

            return await _basketRepository.UpdateBasketAsync(basket, cancellationToken);
        }
    }
}
