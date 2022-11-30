﻿using Microsoft.Build.Framework;

namespace ShopASP.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }


    }
}
