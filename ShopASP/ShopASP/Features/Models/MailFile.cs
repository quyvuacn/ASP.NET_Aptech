namespace ShopASP.Features.Models
{
    public class MailFile
    {
        public string pathFile;
        public bool isAttachment = true;
        public string? cid { get; set; }
    }
}
