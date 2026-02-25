namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public short StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal UnitPrice { get; set; }

        public string ProductImageUrl { get; set; }

        public string CountryOfOrigin { get; set; }

        // Navigation properties

        public List<OrderAll> Orders { get; set; }
    }
}
