using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();
        if (await session.Query<Product>().AnyAsync(cancellation))
            return;

        session.Store<Product>(GetPreconfiguredProducts());
        
        await session.SaveChangesAsync(cancellation);
    }

    private IEnumerable<Product> GetPreconfiguredProducts()
    {
       var products = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "iPhone 14 Pro",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Apple iPhone 14 Pro with 256GB storage",
                ImageFile = "iphone14pro.jpg",
                Price = 999.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy S22 Ultra",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Samsung Galaxy S22 Ultra with 128GB storage",
                ImageFile = "galaxys22ultra.jpg",
                Price = 1199.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Google Pixel 7",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Google Pixel 7 with 128GB storage",
                ImageFile = "pixel7.jpg",
                Price = 699.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "OnePlus 10 Pro",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "OnePlus 10 Pro with 256GB storage",
                ImageFile = "oneplus10pro.jpg",
                Price = 899.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sony Xperia 1 IV",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Sony Xperia 1 IV with 256GB storage",
                ImageFile = "xperia1iv.jpg",
                Price = 949.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Huawei P50 Pro",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Huawei P50 Pro with 256GB storage",
                ImageFile = "p50pro.jpg",
                Price = 999.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Xiaomi Mi 11 Ultra",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Xiaomi Mi 11 Ultra with 256GB storage",
                ImageFile = "mi11ultra.jpg",
                Price = 749.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Oppo Find X5 Pro",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Oppo Find X5 Pro with 256GB storage",
                ImageFile = "findx5pro.jpg",
                Price = 899.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Asus ROG Phone 6",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Asus ROG Phone 6 with 512GB storage",
                ImageFile = "rogphone6.jpg",
                Price = 1099.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Realme GT 2 Pro",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Realme GT 2 Pro with 256GB storage",
                ImageFile = "gt2pro.jpg",
                Price = 799.99m
            }
        };
        return products;
    }
}