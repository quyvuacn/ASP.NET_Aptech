namespace ShopASP.Features.Models
{
    public class FileModel
    {
        public IFormFile FileData { get; set; }
        public string? FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
