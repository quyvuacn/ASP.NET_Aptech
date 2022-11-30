namespace ShopASP.Models
{
    public class ProductComment : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
    }
}
