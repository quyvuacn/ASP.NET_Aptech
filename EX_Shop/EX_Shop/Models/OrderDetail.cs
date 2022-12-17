namespace EX_Shop.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int qty { get; set; }
		public Order? Order { get; set; }
		public Product? Product { get; set; }
	}
}
