using ShopASP.Models;

namespace ShopASP.Areas.Admin.Models
{
	public class CategoryViewModel
	{
		public List<Category>? Categories { get; set; }
		public Category? Category { get; set; }
		public string? search { get; set; }
	}
}
