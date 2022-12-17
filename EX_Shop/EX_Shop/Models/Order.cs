namespace EX_Shop.Models
{
	public class Order
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public double subtotal { get; set; }
		public ICollection<OrderDetail>? OrderDetails { get; set; }
		public Customer? Customer { get; set; }
	}
}
