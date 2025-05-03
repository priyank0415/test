using TechSpeck.Domain.Entities;

namespace TechSpeck.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Products.Any())
        {
            return; // DB has been seeded
        }

        var products = new Product[]
        {
            new Product
            {
                Name = "Smartphone X",
                Description = "Latest smartphone with advanced features",
                Price = 999.99m,
                StockQuantity = 50
            },
            new Product
            {
                Name = "Laptop Pro",
                Description = "High-performance laptop for professionals",
                Price = 1499.99m,
                StockQuantity = 30
            },
            new Product
            {
                Name = "Wireless Headphones",
                Description = "Premium noise-cancelling wireless headphones",
                Price = 299.99m,
                StockQuantity = 100
            },
            new Product
            {
                Name = "Smart Watch",
                Description = "Fitness tracker and smart watch combo",
                Price = 199.99m,
                StockQuantity = 75
            },
            new Product
            {
                Name = "Tablet Mini",
                Description = "Compact tablet for everyday use",
                Price = 399.99m,
                StockQuantity = 40
            }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
} 