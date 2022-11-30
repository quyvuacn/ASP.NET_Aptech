using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using ShopASP.Data;
using ShopASP.Models;

namespace ShopASP.SeedData
{
    public static class SeedData
    {
        public static async void  Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShopASPContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ShopASPContext>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }
                context.User.AddRange(
                    new User
                    {
                        Name = "Quý Vũ",
                        Email = "vuvietquyacn@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        Level = 1,
                    },
                    new User
                    {
                        Name = "admin",
                        Email = "admin@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        Level = 1,
                    }
                );
                await context.SaveChangesAsync();

                if (context.Brand.Any())
                {
                    return;   // DB has been seeded
                }
                context.Brand.AddRange(
                    new Brand
                    {
                        Name = "AMM"
                    }
                );
                await context.SaveChangesAsync();


                if (context.Category.Any())
                {
                    return;   // DB has been seeded
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
                        Name = "Girl"
                    },
                    new Category
                    {
                        Name = "Boy"
                    }
                );
                await context.SaveChangesAsync();

                context.Product.AddRange(
                    new Product
                    {
                        Name = "Váy quấn dài tay",
                        BrandId = 1,
                        CategoryId = 2,
                        Description = "",
                        Price = 35,
                        Sku = "000001",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Váy quấn ngắn tay kèm dây đai",
                        BrandId = 1,
                        CategoryId = 2,
                        Description = "",
                        Price = 40,
                        Sku = "000002",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Váy quấn cổ V vải ecovero",
                        BrandId = 1,
                        CategoryId = 2,
                        Description = "",
                        Price = 30,
                        Sku = "000003",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Váy sơ mi denim thắt eo",
                        BrandId = 1,
                        CategoryId = 2,
                        Description = "",
                        Price = 30,
                        Sku = "000004",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Váy sơ mi denim thắt eo",
                        BrandId = 1,
                        CategoryId = 2,
                        Description = "",
                        Price = 50,
                        Sku = "000005",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Áo denim nữ dáng kimono",
                        BrandId = 1,
                        CategoryId = 2,
                        Description = "",
                        Price = 20,
                        Sku = "000006",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Áo khoác nam khaki cổ V",
                        BrandId = 1,
                        CategoryId = 1,
                        Description = "",
                        Price = 25,
                        Sku = "000007",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Áo khoác nam khaki có túi ngực",
                        BrandId = 1,
                        CategoryId = 1,
                        Description = "",
                        Price = 35,
                        Sku = "000008",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Áo len nam dáng rộng sợi cotton",
                        BrandId = 1,
                        CategoryId = 1,
                        Description = "",
                        Price = 40,
                        Sku = "000009",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Áo sơ mi nam vải poplin dáng rộng",
                        BrandId = 1,
                        CategoryId = 1,
                        Description = "",
                        Price = 15,
                        Sku = "000010",
                        Weight = 0.2
                    },
                    new Product
                    {
                        Name = "Áo sơ mi nam kiểu resort vải kẻ",
                        BrandId = 1,
                        CategoryId = 1,
                        Description = "",
                        Price = 10,
                        Sku = "000010",
                        Weight = 0.2
                    }
                );
                await context.SaveChangesAsync();


                if (context.ProductImage.Any())
                {
                    return;
                }
                context.ProductImage.AddRange(
                    new ProductImage
                    {
                        ProductId= 1,
                        Path = "product_1.1.png"
                    },
                    new ProductImage
                    {
                        ProductId= 1,
                        Path = "product_2.1.png"
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }

}
