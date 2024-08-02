using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ShopEasy.Models;

namespace ShopEasy.Pages
{
    public class CartModel : PageModel
    {
        public Cart ShoppingCart { get; set; } = new Cart();

        public void OnGet()
        {
            LoadShoppingCart();
        }

        public IActionResult OnPostRemove(int productId)
        {
            LoadShoppingCart();
            ShoppingCart.RemoveItem(productId);
            SaveShoppingCart();
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateQuantity(int productId, int quantity)
        {
            LoadShoppingCart();
            ShoppingCart.UpdateItemQuantity(productId, quantity);
            SaveShoppingCart();
            return RedirectToPage();
        }

        private void LoadShoppingCart()
        {
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            if (!string.IsNullOrEmpty(cartJson))
            {
                ShoppingCart = JsonConvert.DeserializeObject<Cart>(cartJson) ?? new Cart();
            }
        }

        private void SaveShoppingCart()
        {
            var cartJson = JsonConvert.SerializeObject(ShoppingCart);
            HttpContext.Session.SetString("ShoppingCart", cartJson);
        }
    }
}
