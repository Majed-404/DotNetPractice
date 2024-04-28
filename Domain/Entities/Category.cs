using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsShowable { get; set; }

        public List<Product> Products { get; set; }
    }
}
