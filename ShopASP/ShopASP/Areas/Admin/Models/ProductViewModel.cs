using ShopASP.Models;

namespace ShopASP.Areas.Admin.Models
{
	public class ProductViewModel
	{
		public List<Product>? Products { get; set; }
		public Product? Product { get; set; }
		public List<Brand>? Brands { get; set; }
		public List<Category>? Categories { get; set; }
		public List<Tag>? Tags { get; set; }
		public List<IFormFile>? Images { get; set; }
		public ProductDetail? ProductDetail { get; set; }
		public string? search { get; set; }
		
	}
}
