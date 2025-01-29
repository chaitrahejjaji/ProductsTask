using Products.Domain.Entities;

namespace Products.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Product product);
    }
}
