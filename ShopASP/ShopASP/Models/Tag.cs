namespace ShopASP.Models
{
    public class Tag : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductTag>? Products { get; set; }
    }
}
