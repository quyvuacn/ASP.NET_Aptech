namespace ShopASP.Models
{
    public class ProductTag : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
