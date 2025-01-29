using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Products.Application.Products.Dtos;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Repositories;

namespace Products.Application.Products
{
    /// <summary>
    /// Implementation of IProductService. It interacts with the repository. 
    /// Accepts all parameters passed on through dependency injection.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="validator"></param>
    internal class ProductService(IProductRepository repository, IMapper mapper, ILogger<ProductService> logger, IValidator<Product> validator) : IProductService
    {
        public async Task<Guid> CreateAsync(ProductCreateDto productDto)
        {
            logger.LogInformation("Creating a product {@Product}", productDto);
            var product = mapper.Map<Product>(productDto);
            var validationResult = validator.Validate(product);
            if (!validationResult.IsValid)
                throw new ValidationException($"Product create was unsuccessfull due to validation errors : {validationResult.ToString()}");

            return await repository.CreateAsync(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            logger.LogInformation($"Getting all products");
            var products = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            logger.LogInformation($"Getting the product: {id}");
            var product = await repository.GetByIdAsync(id);
            if (product is null)
                throw new NotFoundException(nameof(Product), id.ToString());
            return mapper.Map<ProductDto?>(product);
        }
    }
}
