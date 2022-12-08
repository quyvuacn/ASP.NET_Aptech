using Microsoft.AspNetCore.Mvc;
using ShopASP.Models;

namespace ShopASP.Areas.Admin.Models
{
	public class UserViewModel
	{
		public User User { get; set; }
		public List<User> Users { get; set; }
		public UserAddress UserAddress { get; set; }
		public string? rePassword { get; set; }
		public IFormFile? userAvatar { get; set; }
		public string? search { get; set; }
	}
}
