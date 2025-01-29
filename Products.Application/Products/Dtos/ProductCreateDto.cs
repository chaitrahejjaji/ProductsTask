namespace Products.Application.Products.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string ProductCode { get; set; } = default!;
        public decimal Price { get; set; }
        public string SKU { get; set; } = default!;
        public long StockQuantity { get; set; }
    }
}
