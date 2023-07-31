using AutoMapper;
using Discount.DataAccess.Entities;
using Discount.DataAccess.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(
            IDiscountRepository discountRepository,
            IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _discountRepository.GetDiscountAsync(request.ProductName);
            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CreateDiscountMessage> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            var result = await _discountRepository.CreateAsync(coupon);

            if (result)
            {
                return _mapper.Map<CreateDiscountMessage>(result);
            }

            throw new RpcException(new Status(StatusCode.Internal, "Create operation failed", result.Exception));
        }

        public override async Task<UpdateDiscountMessage> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            var result = await _discountRepository.UpdateAsync(coupon);

            if (result)
            {
                return _mapper.Map<UpdateDiscountMessage>(result);
            }

            throw new RpcException(new Status(StatusCode.Internal, "Update operation failed", result.Exception));
        }

        public override async Task<DeleteDiscountMessage> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var result = await _discountRepository.DeleteCouponAsync(request.ProductName);

            if (result)
            {
                return _mapper.Map<DeleteDiscountMessage>(result);
            }

            throw new RpcException(new Status(StatusCode.Internal, "Delete operation failed", result.Exception));
        }
    }
}
