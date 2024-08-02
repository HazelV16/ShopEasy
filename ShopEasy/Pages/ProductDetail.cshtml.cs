using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ShopEasy.Models;

namespace ShopEasy.Pages
{
	public class ProductDetailModel : PageModel
    {
        public Product Product { get; set; }

        //public IActionResult OnGet(int id)
        //{
        //    Product = ProductRepo.Products.Find(p => p.Id == id);
        //    if (Product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Page();
        //}

        public void OnGet(int id)
        {
            // Simulate loading the product from a database.
            Product = GetProductById(id);
        }

        private Product GetProductById(int id)
        {
            // This should ideally fetch the product from a database.
            // Here we use hardcoded data for demonstration purposes.
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Cat", Description = "Fluffy cat", Price = 20.99, Stock = 10, ImgURl = "/Images/cat.webp" },
                new Product { Id = 2, Name = "Dinosaur", Description = "Fluffy dinosaur", Price = 14.99, Stock = 15, ImgURl = "/Images/dinosaur.jpg" },
                new Product { Id = 3, Name = "Corgi", Description = "Fluffy corgi", Price = 16.99, Stock = 20, ImgURl = "/Images/corgi.png" }
            };

            return products.Find(p => p.Id == id);
        }

        public IActionResult OnPost(int productId, string name, decimal price)
        {
            var cart = GetShoppingCart();
            cart.AddItem(productId, name, price);
            SaveShoppingCart(cart);
            return RedirectToPage("/Cart");
        }

        private Cart GetShoppingCart()
        {
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            return string.IsNullOrEmpty(cartJson) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartJson);
        }

        private void SaveShoppingCart(Cart cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("ShoppingCart", cartJson);
        }
    }
}
