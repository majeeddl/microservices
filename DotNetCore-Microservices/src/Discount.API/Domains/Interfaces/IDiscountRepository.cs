using Discount.API.Domains.Entities;

namespace Discount.API.Domains.Interfaces
{
    public interface IDiscountRepository
    {

        Task<Coupon> GetDiscount(string productName);

        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);

    }
}
