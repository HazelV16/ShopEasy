﻿using System;
namespace ShopEasy.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public int Stock { get; set; }
		public string ImgURl { get; set; }
	}
}

