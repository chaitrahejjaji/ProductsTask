using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Repositories;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories
{
    /// <summary>
    /// Implementaion of IProductRepository. It communicates with the ProductsDbContext.
    /// </summary>
    /// <param name="context"></param>
    internal class ProductRepository(ProductsDbContext context) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Guid> CreateAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            //EF populates the Id
            return product.Id;
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
