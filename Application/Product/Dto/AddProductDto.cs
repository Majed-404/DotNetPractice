namespace Application.Product.Dto
{
    public class AddProductDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public double Coast { get; set; }
        public int StockQuantity { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
