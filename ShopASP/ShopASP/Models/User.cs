namespace ShopASP.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public int Level { get; set; }

        public User() {
            Avatar = "default-user.png";
        }
    }
}
