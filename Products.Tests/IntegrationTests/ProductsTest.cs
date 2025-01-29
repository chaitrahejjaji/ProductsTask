using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Products.Domain.Entities;
using System.Net;
using System.Net.Http.Json;

namespace Products.Tests.IntegrationTests
{
    /// <summary>
    /// Integration tests for the API- tests a few valid and error scenarios 
    /// </summary>
    public class ProductsTest
    {
        private const string ApiUrl = "api/products";
        const string testProductId = "ef113830-f9ef-425f-e16a-08dd3d2c0ead";
        [Fact]
        public async Task GetAll_ReturnsProducts()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetAsync(ApiUrl);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(products);
            Assert.NotEmpty(products);
        }

        [Fact]
        public async Task GetById_ReturnsAProduct()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            //Trying to get a product that should have already been seeded into the database            
            var response = await client.GetAsync($"{ApiUrl}/{testProductId}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(product);
            Assert.Equal(testProductId, product.Id.ToString());
        }

        [Fact]
        public async Task GetById_NonExistingProduct_ReturnsNotFound()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            //Trying to get a product that should not exist in the database            
            var response = await client.GetAsync($"{ApiUrl}/{Guid.NewGuid()}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsPath()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            string name = Guid.NewGuid().ToString();
            Product testProduct = GetANewTestProduct();
            var response = await client.PostAsJsonAsync(ApiUrl, testProduct);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var productUrl = response.Headers.Location;
            //Now get the product using the url returned 
            response = await client.GetAsync(productUrl);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(product);
            Assert.Equal(testProduct.Name, product.Name);
        }

        [Fact]
        public async Task Create_WithEmptyFields_ReturnsError()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var testProduct = new Product() { Name = string.Empty, Category = string.Empty, Price = 0, StockQuantity = 0, ProductCode = string.Empty, SKU = string.Empty };
            var response = await client.PostAsJsonAsync(ApiUrl, testProduct);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private static Product GetANewTestProduct()
        {
            return new Product() { Name = $"Food {Guid.NewGuid()}", Category = "Food", Price = 9, StockQuantity = 100, ProductCode = "KF123456", SKU = "KF_123_456" };
        }

    }

}