using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Products;

namespace Products.Application.Extensions
{
    /// <summary>
    /// Extension class to add all Application dependencies to the service container
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>(); 
            System.Reflection.Assembly currentAssembly = typeof(ApplicationServiceExtensions).Assembly;
            services.AddAutoMapper(currentAssembly);
            services.AddValidatorsFromAssembly(currentAssembly).AddFluentValidationAutoValidation();
        }
    }
}
