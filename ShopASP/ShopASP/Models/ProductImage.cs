namespace ShopASP.Models
{
    public class ProductImage : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
        public Product? Product { get; set; }
    }
}
