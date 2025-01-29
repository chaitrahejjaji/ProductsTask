using Products.Domain.Entities;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Seeders
{
    /// <summary>
    /// Seeder class to insert some default seed data
    /// </summary>
    /// <param name="context">Productscontext passed on through dependency injection</param>
    internal class ProductSeeder(ProductsDbContext context) : IProductSeeder
    {
        public async Task Seed()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Products.Any())
                {
                    var products = GetProducts();
                    context.Products.AddRange(products);
                    await context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            List<Product> products = [
                new()
            {
               Id=new Guid("ef113830-f9ef-425f-e16a-08dd3d2c0ead"),
               Category = "Food",
               Name = "Almonds",
               DateAdded = DateTime.Today,
               Price = 2.99m,
               ProductCode = "KF944RUR",
               StockQuantity = 1100,
               SKU="KF-944-RUR"
            },
            new ()
            {
               Category = "Food",
               Name = "Cashews",
               DateAdded = DateTime.Today.AddDays(-90),
               Price = 2.59m,
               ProductCode = "KF924RUR",
               StockQuantity = 2300,
               SKU="KF-924-RUR"
            },
             new ()
            {
               Category = "Clothes",
               Name = "Striped Polo",
               DateAdded = DateTime.Today.AddDays(-200),
               Price = 22.99m,
               ProductCode = "KC724RUR",
               StockQuantity = 82,
               SKU="KC-724-RUR"
            },
             new ()
            {
               Category = "Clothes",
               Name = "Knitted Jumper",
               DateAdded = DateTime.Today.AddDays(-210),
               Price = 29.99m,
               ProductCode = "KC984RUR",
               StockQuantity = 50,
               SKU="KC-98-4RUR"
            },
             new ()
            {
               Category = "Clothes",
               Name = "Khaki Trousers",
               DateAdded = DateTime.Today.AddDays(-210),
               Price = 29.99m,
               ProductCode = "KC184RUR",
               StockQuantity = 200,
               SKU="KC-184-RUR"
            },
             new ()
            {
               Category = "Electronics",
               Name = "iPhone Y",
               DateAdded = DateTime.Today.AddDays(-30),
               Price = 999.99m,
               ProductCode = "KE084RUR",
               StockQuantity = 200,
               SKU="KE-08-4RUR"
            },
            ];

            return products;
        }
    }
}
