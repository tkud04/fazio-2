using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ass_2.Data;
using System;
using System.Linq;

namespace ass_2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ass_2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ass_2Context>>()))
            {
                // Look for any products.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Title = "3D Perspiration Sport Quick Drying Long Sleeve T Shirt",
                        ReleaseDate = DateTime.Parse("2021-6-3"),
                        Category = 1,
						Sku = "FAZ3YTT355",
                        Price = 19.99M
                    },
					new Product
                    {
                        Title = "Men's Official Corporate Shirt",
                        ReleaseDate = DateTime.Parse("2021-6-3"),
                        Category = 1,
						Sku = "FAZ77HR414",
                        Price = 29.99M
                    },
					new Product
                    {
                        Title = "D'Andre Skeen Leather Tshirt",
                        ReleaseDate = DateTime.Parse("2021-6-3"),
                        Category = 1,
						Sku = "FAZ6HG2160",
                        Price = 16.99M
                    },
					new Product
                    {
                        Title = "White Pocket Marshmallow Polo Tshirt Round Neck",
                        ReleaseDate = DateTime.Parse("2021-6-3"),
                        Category = 1,
						Sku = "FAZ22WQ56K",
                        Price = 19.99M
                    },
					new Product
                    {
                        Title = "Black 01Lifestyle Tshirt",
                        ReleaseDate = DateTime.Parse("2021-6-3"),
                        Category = 1,
						Sku = "FAZ8AA21WQ",
                        Price = 10.99M
                    }

                    
                );
                context.SaveChanges();
            }
        }
    }
}