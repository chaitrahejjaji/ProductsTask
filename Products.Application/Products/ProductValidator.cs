using FluentValidation;
using Products.Domain.Entities;

namespace Products.Application.Products
{
    /// <summary>
    /// A FluentValidation class to put-together all validations for Product entity
    /// </summary>
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).Length(1, 80).WithMessage("{PropertyName} should be non empty with length less than 80 characters.");
            RuleFor(x => x.Category).Length(1,80).WithMessage("{PropertyName} should be non empty with length less than 80 characters."); 
            RuleFor(x => x.ProductCode).Length(1, 10).WithMessage("{PropertyName} should be non empty with length less than 10 characters."); ;
            RuleFor(x => x.SKU).Length(10).WithMessage("{PropertyName} should be non empty and of 10 characters.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("{PropertyName} must be more than 1.");
            RuleFor(x => x.StockQuantity).GreaterThan(0).WithMessage("{PropertyName} must be more than 1.");
        }
    }
}
