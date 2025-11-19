using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Web_Shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public double Price { get; set; } = 0.0;
        public string Description { get; set; } = string.Empty;

        [AllowNull]
        public string ImageUrl { get; set; } = string.Empty;
        
    }
}
