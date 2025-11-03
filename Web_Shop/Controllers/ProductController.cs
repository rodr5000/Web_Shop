using Microsoft.AspNetCore.Mvc;
using ShopSbS.Data;
using System.Diagnostics;
using Web_Shop.Models;

namespace Web_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult IndexPr()
        {
            var products = _context.Products.ToList();
            return View(products);
        }


    }
}
