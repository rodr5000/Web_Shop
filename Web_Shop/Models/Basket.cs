namespace Web_Shop.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public Item Item { get; set; }

        public ShoppingCart Cart { get; set; }
    }
}
