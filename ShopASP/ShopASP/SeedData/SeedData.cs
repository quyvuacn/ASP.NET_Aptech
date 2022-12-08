using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using ShopASP.Data;
using ShopASP.Models;

namespace ShopASP.SeedData
{
    public static class SeedData
    {
        public static void  Initialize(IServiceProvider serviceProvider)
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
                        Phone = "0326459773",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        Level = 1,
                    },
                    new User
                    {
                        Name = "admin",
                        Email = "admin@gmail.com",
                        Phone = "0969264559",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        Level = 1,
                    }
                );
                context.SaveChanges();

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
                context.SaveChanges();


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
                context.SaveChanges();

                if (context.Tag.Any())
                {
                    return;   // DB has been seeded
                }
                context.Tag.AddRange(
                    new Tag
                    {
                        //Id = 1
                        Name = "Tops"
                    },
                    new Tag
                    {
                        //Id = 2
                        Name = "Coats"
                    },
                    new Tag
                    {
                        //Id = 3
                        Name = "Jackets"
                    },
                    new Tag
                    {
                        //Id = 4
                        Name = "T-Shirts"
                    }, 
                    new Tag
                    {
                        //Id = 5
                        Name = "Denim"
                    },
                    new Tag
                    {
                        //Id = 6
                        Name = "Dress"
                    }
                );
                context.SaveChanges();

                context.Product.AddRange(
                    new Product
                    {
                        //Id = 1
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
                        //Id = 2
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
                        //Id = 3
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
                        //Id = 4
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
                        //Id = 5
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
                        //Id = 6
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
                        //Id = 7
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
                        //Id = 8
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
                        //Id = 9
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
                        //Id = 10
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
                        //Id = 11
                        Name = "Áo sơ mi nam kiểu resort vải kẻ",
                        BrandId = 1,
                        CategoryId = 1,
                        Description = "",
                        Price = 10,
                        Sku = "000010",
                        Weight = 0.2
                    }
                );
                context.SaveChanges();

                if (context.ProductTag.Any())
                {
                    return;
                }
                context.ProductTag.AddRange(
                    new ProductTag
                    {
                        ProductId = 1,
                        TagId = 1,
                    },
                    new ProductTag
                    {
                        ProductId = 1,
                        TagId = 2,
                    },
                    new ProductTag
                    {
                        ProductId = 1,
                        TagId = 3,
                    },
                    new ProductTag
                    {
                        ProductId = 1,
                        TagId = 4,
                    },
                    new ProductTag
                    {
                        ProductId = 1,
                        TagId = 5,
                    }
                );
                context.SaveChanges();
            }
        }
    }

}
