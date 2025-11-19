using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopSbS.Data;
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
        public IActionResult CreatePr()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePr(Product product)
        {
            if (ModelState.IsValid)
            {
                // If the user entered an image name, prepend /images/
                if (!string.IsNullOrWhiteSpace(product.ImageUrl) && !product.ImageUrl.StartsWith("/images/"))
                {
                    product.ImageUrl = "/images/" + product.ImageUrl.TrimStart('/');
                }
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexPr));
            }
            return View(product);


        }
        public async Task<IActionResult> EditPr(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,ImageUrl")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!productExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexPr));
            }
                return View(product);
        }
        public async Task<IActionResult> DetailsPr(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public async Task<IActionResult> DeletePr(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        [HttpPost, ActionName("DeletePr")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexPr));
        }
        private bool productExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
