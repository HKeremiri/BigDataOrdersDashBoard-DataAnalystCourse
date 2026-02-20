namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
