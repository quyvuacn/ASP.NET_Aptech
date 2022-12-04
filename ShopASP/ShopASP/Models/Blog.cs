namespace ShopASP.Models
{
    public class Blog : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Image { get; set; }
        public string Tag { get; set; }
        public string Content { get; set; }
        public ICollection<BlogComment>? BlogComments { get; set; }

	}
}
