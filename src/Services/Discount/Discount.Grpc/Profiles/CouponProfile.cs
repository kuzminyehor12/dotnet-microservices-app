using AutoMapper;
using Discount.DataAccess.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponModel>()
                .ReverseMap();
        }
    }
}
