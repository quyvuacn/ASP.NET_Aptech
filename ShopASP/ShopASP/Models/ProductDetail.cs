namespace ShopASP.Models
{
    public class ProductDetail : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Qty { get; set; }

    }
}
