using Products.Application.Products.Dtos;

namespace Products.Application.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(ProductCreateDto product);
    }
}
