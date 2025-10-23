namespace Web_Shop.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public item item { get; set; }

        public ShoppingCart cart { get; set; }
    }
}
