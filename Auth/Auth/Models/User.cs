using Microsoft.AspNetCore.Identity;

namespace Auth.Models
{
	public class User : IdentityUser
	{
		public string Address { get; set; }
	}
}
