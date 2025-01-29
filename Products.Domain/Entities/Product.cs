using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [StringLength(80)]
        public string Name { get; set; } = default!;

        [StringLength(50)]
        public string Category { get; set; } = default!;

        [StringLength(10)]
        public string ProductCode { get; set; } = default!;

        public decimal Price { get; set; }

        [StringLength(10)]
        public string SKU { get; set; } = default!;

        public long StockQuantity { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

    }
}
