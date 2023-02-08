using System.Net;
using AutoMapper;
using Basket.API.Domains.Entities;
using Basket.API.Domains.Interfaces;
using Basket.API.GrpcServices;
using Discount.Grpc.Protos;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Adapters
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcServices _discountProtoService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, DiscountGrpcServices discountProtoService,
            IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _discountProtoService = discountProtoService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket = await this._basketRepository.GetBasket(username);

            return Ok(basket ?? new ShoppingCart(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket(ShoppingCart shoppingCart)
        {
            //TODO : communicate with Discount.Grpc and calculate latest price of product into shopping card
            foreach (var item in shoppingCart.Items)
            {
                var coupon = await _discountProtoService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            return Ok(await this._basketRepository.UpdateBasket(shoppingCart));
        }

        [HttpDelete("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket(string username)
        {
            await this._basketRepository.DeleteBasket(username);

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            //Get existing basket with total price
            //Set total price on basketcheckout event message
            //Send chekout event to rabbitmq
            //Remove the basket

            //Get  existing basket with total price
            var basket = await _basketRepository.GetBasket(basketCheckout.UserName);
            if (basket == null)
            {
                return BadRequest();
            }

            //Send message event to rabbitmq
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.TotalPrice = basket.TotalPrice;
            await _publishEndpoint.Publish<BasketCheckoutEvent>(basket.Username);


            //remove the basket
            await _basketRepository.DeleteBasket(basket.Username);


            return Accepted();

        }
    }
}
