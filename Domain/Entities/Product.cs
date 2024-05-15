using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; } //PK
        public string NameAr { get; set; }
        
        public string? NameEn { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Coast { get; set; }
        public int StockQuantity { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductAttachment> Attachments { get; set; }

        private Product(string nameAr,string nameEn, string description, decimal price, double coast, int stockQuantity,int? categoryId)
        {
            if(string.IsNullOrWhiteSpace(nameAr))
                throw new ArgumentNullException("Product Arabic name cannot be null or empty.");

            if (price < 0)
                throw new ArgumentOutOfRangeException("Price cannot be less than zero");

            if (coast < 0)
                throw new ArgumentOutOfRangeException("Coast cannot be less than zero");

            if (stockQuantity < 0)
                throw new ArgumentOutOfRangeException("Coast cannot be less than zero");

            NameAr = nameAr;
            NameEn = nameEn;
            Description = description;
            Price = price;
            Coast = coast;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
        }

        public static Product Create(string nameAr, string nameEn, string description, decimal price, double coast,
                        int stockQuantity, int? categoryId)
        {
            return new Product(nameAr, nameEn, description, price, coast, stockQuantity, categoryId);
        }

        public void SetAttachments(List<ProductAttachment> attachments)
        {
            if (attachments is null)
                throw new ArgumentNullException("Product attachments cannot be null");

            //if (attachments.Count == 0)
            //    throw new DomainException("attachments count cannot equal to 0");
            Attachments.AddRange(attachments);
        }
    }
}
