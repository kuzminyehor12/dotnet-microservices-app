using Basket.API.Extensions;
using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountGrpcClient;
        private readonly ILogger<DiscountGrpcService> _logger;

        public DiscountGrpcService(
            DiscountProtoService.DiscountProtoServiceClient discountGrpcClient,
            ILogger<DiscountGrpcService> logger)
        {
            _discountGrpcClient = discountGrpcClient;
            _logger = logger;
        }

        public async Task<CouponModel> GetDiscountAsync(string productName)
        {
            try
            {
                var discountRequest = new GetDiscountRequest { ProductName = productName };
                return await _discountGrpcClient.GetDiscountAsync(discountRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return CouponFactory.NoCoupon();
            }
        }
    }
}
