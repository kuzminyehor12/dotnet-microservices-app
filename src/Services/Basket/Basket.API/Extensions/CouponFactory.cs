using Discount.Grpc.Protos;

namespace Basket.API.Extensions
{
    public static class CouponFactory
    {
        public static CouponModel NoCoupon()
        {
            return new CouponModel
            {
                ProductName = "No Discount",
                Amount = 0,
                Description = "No Discount"
            };
        }
    }
}
