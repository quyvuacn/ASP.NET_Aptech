namespace ShopASP.Models
{
    public class UserAddress : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public User? User { get; set; }

    }
}
