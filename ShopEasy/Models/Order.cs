using System;
using System.ComponentModel.DataAnnotations;

namespace ShopEasy.Models
{
	public class Order
	{
		public string Name { get; set; }
		public string Address { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		[Phone]
		public string Phone { get; set; }
	}
}

