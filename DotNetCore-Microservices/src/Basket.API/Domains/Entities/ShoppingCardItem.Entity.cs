namespace Basket.API.Domains.Entities;

public class ShoppingCardItem
{
    public int Quantity { get; set; }

    public string Color{ get; set; }

    public decimal Price { get; set; }

    public string ProductId { get; set; }
    public string ProductName { get; set; }
}