using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopASP.Models
{
    public class ProductTag
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public Tag? Tag { get; set; }

    }
}
