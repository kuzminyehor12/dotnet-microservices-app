using Discount.API.Models;
using Discount.API.Entities;

namespace Discount.API.Repositories
{
    public interface IDiscountRepository : IBaseRepository<Coupon>
    {
        Task<Coupon> GetDiscountAsync(string productName, CancellationToken cancellationToken = default);

        Task<Result> DeleteCouponAsync(string productName, CancellationToken cancellationToken = default);
    }
}
