using System;
using Microsoft.CodeAnalysis;

namespace ShopEasy.Models
{
	public class Cart
	{
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(int productId, string name, decimal price)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = productId,
                    Name = name,
                    Price = price,
                    Quantity = 1
                });
            }
        }

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public void UpdateItemQuantity(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        public decimal TotalPrice()
		{
            return Items.Sum(i => i.Price * i.Quantity);
        }
	}
}

