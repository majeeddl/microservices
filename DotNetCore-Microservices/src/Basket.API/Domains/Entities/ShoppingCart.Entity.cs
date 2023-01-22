namespace Basket.API.Domains.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();


        public ShoppingCart()
        {
            
        }
        public ShoppingCart(string username)
        {
            Username = username;
        }

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Price + item.Quantity);
            }
        }
    }
}
