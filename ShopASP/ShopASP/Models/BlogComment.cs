namespace ShopASP.Models
{
    public class BlogComment : BaseEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}
