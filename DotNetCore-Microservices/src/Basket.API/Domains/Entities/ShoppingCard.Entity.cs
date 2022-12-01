namespace Basket.API.Domains.Entities
{
    public class ShoppingCard
    {
        public string Username { get; set; }

        public List<ShoppingCardItem> Items { get; set; } = new List<ShoppingCardItem>();

        public ShoppingCard(string username)
        {
            Username = username;
        }
    }
}
