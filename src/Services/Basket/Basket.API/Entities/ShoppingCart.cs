namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public IEnumerable<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public bool IsEmpty => Items.Count() == 0;

        public static ShoppingCart Empty(string userName)
        {
            return new ShoppingCart
            {
                UserName = userName,
            };
        }
    }
}
