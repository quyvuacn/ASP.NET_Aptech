using Microsoft.EntityFrameworkCore;


namespace ShopASP.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string Sku { get; set; }

        public Category Category { get; set; }
		public Brand Brand { get; set; }

		public ICollection<ProductTag>? ProductComment { get; set; }
		public ICollection<ProductComment>? ProductComments { get; set; }
		public ICollection<ProductImage>? ProductImages { get; set; }
		public ICollection<ProductDetail>? ProductDetails { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }

	}
}
