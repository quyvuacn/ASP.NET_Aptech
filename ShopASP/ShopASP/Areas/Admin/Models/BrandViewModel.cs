using ShopASP.Models;

namespace ShopASP.Areas.Admin.Models
{
	public class BrandViewModel
	{
		public List<Brand>? Brands { get; set; }
		public Brand Brand { get; set; }
		public string? search { get; set; }
	}
}
