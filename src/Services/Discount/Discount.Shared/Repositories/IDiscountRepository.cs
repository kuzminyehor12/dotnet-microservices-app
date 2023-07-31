using Discount.DataAccess.Models;
using Discount.DataAccess.Entities;

namespace Discount.DataAccess.Repositories
{
    public interface IDiscountRepository : IBaseRepository<Coupon>
    {
        Task<Coupon> GetDiscountAsync(string productName, CancellationToken cancellationToken = default);

        Task<Result> DeleteCouponAsync(string productName, CancellationToken cancellationToken = default);
    }
}
