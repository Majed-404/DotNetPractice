using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; } //PK
        public string NameAr { get; set; }
        
        public string? NameEn { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Coast { get; set; }
        public int StockQuantity { get; set; }

        [ForeignKey(nameof(category))]
        public int categoryId { get; set; }
        public Category category { get; set; }
        public List<ProductAttachment> Attachments { get; set; }
    }
}
