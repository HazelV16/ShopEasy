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
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public Order order { get; set; }
        public Cart CurrentShoppingCart { get; set; }

        public void OnGet()
        {
            CurrentShoppingCart = GetShoppingCart();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            ClearShoppingCart();
            return RedirectToPage("Confirmation");
        }

        private Cart GetShoppingCart()
        {
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            return string.IsNullOrEmpty(cartJson) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartJson);
        }

        private void ClearShoppingCart()
        {
            HttpContext.Session.Remove("ShoppingCart");
        }
    }
}
