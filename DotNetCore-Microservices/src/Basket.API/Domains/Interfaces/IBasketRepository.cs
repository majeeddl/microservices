using System;
using Basket.API.Domains.Entities;

namespace Basket.API.Domains.Interfaces
{
	public interface IBasketRepository
	{
		Task<ShoppingCart?> GetBasket(string username);

		Task<ShoppingCart?> UpdateBasket(ShoppingCart basket);

		Task DeleteBasket(string username);
	}
}

