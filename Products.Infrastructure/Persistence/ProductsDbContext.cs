using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Infrastructure.Persistence
{
    internal class ProductsDbContext(DbContextOptions<ProductsDbContext> options) : DbContext(options)
    {
        internal DbSet<Product> Products { get; set; }
       
    }
}
