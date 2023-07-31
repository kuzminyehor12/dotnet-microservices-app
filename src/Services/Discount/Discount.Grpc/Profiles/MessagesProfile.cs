using AutoMapper;
using Discount.DataAccess.Models;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Profiles
{
    public class MessagesProfile : Profile
    {
        public MessagesProfile()
        {
            CreateMap<Result, CreateDiscountMessage>()
                .ForMember(message => message.IsSuccess, options => options
                    .MapFrom(result => result.IsSuccess));

            CreateMap<Result, UpdateDiscountMessage>()
                .ForMember(message => message.IsSuccess, options => options
                    .MapFrom(result => result.IsSuccess));

            CreateMap<Result, DeleteDiscountMessage>()
                .ForMember(message => message.IsSuccess, options => options
                    .MapFrom(result => result.IsSuccess));
        }
    }
}
