using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ShopEasy.Models;

namespace ShopEasy.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; private set; } = new List<Product>();

        public void OnGet()
        {
            // Load products (this would typically come from a database)
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Cat", Description = "Fluffy cat", Price = 20.99, Stock = 10, ImgURl = "/Images/cat.webp" },
                new Product { Id = 2, Name = "Dinosaur", Description = "Fluffy dinosaur", Price = 14.99, Stock = 15, ImgURl = "/Images/dinosaur.jpg" },
                new Product { Id = 3, Name = "Corgi", Description = "Fluffy corgi", Price = 16.99, Stock = 20, ImgURl = "/Images/corgi.png" }
            };
        }

        public IActionResult OnPostAddToCart(int productId, string name, decimal price)
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


//new Product { Id = 1, Name = "Cat", Description = "Fluffy cat", Price = 20.99, Stock = 10, ImgURl = "/Images/cat.jpg" },
//            new Product { Id = 2, Name = "Dinosaur", Description = "Fluffy dinosaur", Price = 14.99, Stock = 15, ImgURl = "/Images/dinosaur.jpg" },
//            new Product { Id = 3, Name = "corgi", Description = "Fluffy corgi", Price = 16.99, Stock = 20, ImgURl = "/Images/corgi.png" }

