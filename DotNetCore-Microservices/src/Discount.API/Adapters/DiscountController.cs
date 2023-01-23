using Discount.API.Domains.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Adapters
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            this._discountRepository = discountRepository;
        }


        [HttpGet("{productName}", Name= "GetDiscount")]
        public async Task<ActionResult> GetDiscount(string productName)
        {
            var coupon = await this._discountRepository.GetDiscount(productName);

            return Ok(coupon);
        }
    }
}
