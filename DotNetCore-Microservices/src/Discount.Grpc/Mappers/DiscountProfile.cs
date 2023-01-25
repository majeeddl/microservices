using AutoMapper;
using Discount.Grpc.Domains.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mappers
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>();
        }
    }
}
