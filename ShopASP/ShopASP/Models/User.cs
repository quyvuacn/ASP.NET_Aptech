using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopASP.Models
{
    public class User : BaseEntity
    {
		public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
		public string Password { get; set; }
        public string Avatar { get; set; } = "default-user.png";

		public int Level { get; set; }
		public ICollection<Order>? Orders { get; set; }
		public ICollection<UserAddress>? UserAddress { get; set; }
		
    }
}
