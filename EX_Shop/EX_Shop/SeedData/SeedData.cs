using EX_Shop.Data;
using EX_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EX_Shop.SeedData
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new EX_ShopContext(
				serviceProvider.GetRequiredService<
					DbContextOptions<EX_ShopContext>>()))
			{
				if(context.Customer.Any()){
					return;
				}
				context.Customer.AddRange(
					new Customer
					{
						Name = "Vũ Viết Quý",
						Address = "Thái Thụy, Thái Bình",
						Phone = "0326459773"
					}
				);

				context.SaveChanges();

				if (context.Category.Any())
				{
					return;
				}

				context.Category.AddRange(
					new Category
					{
						Name = "Men"
					},
					new Category
					{
						Name = "Women"
					},
					new Category
					{
						Name = "Kid"
					}
				);
				context.SaveChanges();

				context.Product.AddRange(
					new Product
					{
						CategoryId = 1,
						Name = "Quần đùi",
						Description = "Quần mới giá rẻ",
						Price = 20
					},
					new Product
					{
						CategoryId = 2,
						Name = "Váy ngắn",
						Description = "Váy mới giá rẻ",
						Price = 25
					}
				);
				context.SaveChanges();

			}
		}
	}
}
