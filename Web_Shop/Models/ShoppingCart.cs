using System.ComponentModel.DataAnnotations;

namespace Web_Shop.Models
{
    public class ShoppingCart
    {
        
        public int Id { get; set; }
        [Required]
        public int customerID { get; set; }
    }
}
