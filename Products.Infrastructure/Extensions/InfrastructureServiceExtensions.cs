using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Repositories;
using Products.Infrastructure.Persistence;
using Products.Infrastructure.Repositories;
using Products.Infrastructure.Seeders;

namespace Products.Infrastructure.Extensions
{
    /// <summary>
    /// Extension class to add all infrastructure dependencies to the service container
    /// </summary>
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, string contentRootPath)
        {
            services.AddDbContext<ProductsDbContext>(options =>
            {
                string? connectionString = configuration.GetConnectionString("DefaultConnection");
                connectionString = connectionString!.Replace("[DataDirectory]", contentRootPath);

                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IProductSeeder, ProductSeeder>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
