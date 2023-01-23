using System.Net;
using Basket.API.Domains.Entities;
using Basket.API.Domains.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Adapters
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this._basketRepository = basketRepository;
        }

        [HttpGet("{username}",Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket = await this._basketRepository.GetBasket(username);

            return Ok(basket ?? new ShoppingCart(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket(ShoppingCart shoppingCart)
        {
            return Ok(await this._basketRepository.UpdateBasket(shoppingCart));
        }

        [HttpDelete("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket(string username)
        {
            await this._basketRepository.DeleteBasket(username);

            return Ok();
        }
    }
}
