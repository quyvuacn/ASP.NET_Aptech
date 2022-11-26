namespace ASP.NET_VSCode.Models
{
    public class Team
    {
        public Team(string Name,string Logo) {
            this.Name = Name;
            this.Logo = Logo;
        }
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
