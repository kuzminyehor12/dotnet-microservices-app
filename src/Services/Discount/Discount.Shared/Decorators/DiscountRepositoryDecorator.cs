using Discount.DataAccess.Models;
using Discount.DataAccess.Entities;
using Discount.DataAccess.Repositories;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace Discount.DataAccess.Decorators
{
    public class DiscountRepositoryDecorator : IDiscountRepository
    {
        private readonly DiscountRepository _discountRepository;
        private readonly ILogger<DiscountRepositoryDecorator> _logger;

        public DiscountRepositoryDecorator(
            NpgsqlConnection connection, 
            ILogger<DiscountRepositoryDecorator> logger)
        {
            _discountRepository = new DiscountRepository(connection);
            _logger = logger;
        }

        public async Task<Result> CreateAsync(Coupon entity, CancellationToken cancellationToken = default)
        {
            var result = await _discountRepository.CreateAsync(entity, cancellationToken);

            if (result)
            {
                _logger.LogInformation("Coupon has been added successfully.");
                return result;
            }

            _logger.LogError($"There are error while creating a coupon. {result.Exception?.ToString()}");
            return result;
        }

        public async Task<Result> DeleteCouponAsync(string productName, CancellationToken cancellationToken = default)
        {
            var result = await _discountRepository.DeleteCouponAsync(productName, cancellationToken);

            if (result)
            {
                _logger.LogInformation("Coupon has been deleted successfully.");
                return result;
            }

            _logger.LogError($"There are error while deleting the coupon. {result.Exception?.ToString()}");
            return result;
        }

        public Task<Coupon> GetDiscountAsync(string productName, CancellationToken cancellationToken = default)
        {
            return _discountRepository.GetDiscountAsync(productName, cancellationToken);
        }

        public async Task<Result> UpdateAsync(Coupon entity, CancellationToken cancellationToken = default)
        {
            var result = await _discountRepository.UpdateAsync(entity, cancellationToken);

            if (result)
            {
                _logger.LogInformation("Coupon has been updated successfully.");
                return result;
            }

            _logger.LogError($"There are error while updating a coupon. {result.Exception?.ToString()}");
            return result;
        }
    }
}
