using System;
using Basket.API.Domains.Entities;
using Basket.API.Domains.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Frameworks.Data
{
	public class BasketRepository : IBasketRepository
	{

		private readonly IDistributedCache _redisCache;

		public BasketRepository(IDistributedCache redisCache)
		{
            this._redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
		}

        public async Task<ShoppingCart?> GetBasket(string username)
        {
            var basket  = await this._redisCache.GetStringAsync(username);

            return string.IsNullOrEmpty(basket) ? null : JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart?> UpdateBasket(ShoppingCart basket)
        {
            await this._redisCache.SetStringAsync(basket.Username , JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.Username);
        }

        public async Task DeleteBasket(string username)
        {
            await this._redisCache.RemoveAsync(username);
        }
    }
}

