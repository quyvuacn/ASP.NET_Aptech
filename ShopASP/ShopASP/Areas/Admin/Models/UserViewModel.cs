using Microsoft.AspNetCore.Mvc;
using ShopASP.Models;

namespace ShopASP.Areas.Admin.Models
{
	public class UserViewModel
	{
		[BindProperty]
		public User User { get; set; }
		[BindProperty]
		public UserAddress UserAddress { get; set; }
		[BindProperty]
		public string rePassword { get; set; }
		public IFormFile? userAvatar { get; set; }
	}
}
