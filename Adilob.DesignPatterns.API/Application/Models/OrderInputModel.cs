using Adilob.DesignPatterns.API.Core.Enums;

namespace Adilob.DesignPatterns.API.Application.Models
{
	public class OrderInputModel
	{
		public string CustomerId { get; set; }
		public string ProductId { get; set; }
		public PaymentInfo PaymentInfo { get; set; }
        public bool IsInternational { get; set; }
        public CustomerInputModel Customer { get; set; }
        public decimal TotalPrice { get; set; }
		public List<OrderItemInputModel> Items { get; set; }
	}

	public class OrderItemInputModel
	{
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}

	public class PaymentInfo
	{
		public PaymentMethod PaymentMethod { get; set; }
		public string PaymentDetails { get; set; }
	}

	public class CustomerInputModel : ICloneable
	{
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
		private string RandomName { get; set; }
        public string Document { get; set; }

        public CustomerInputModel()
        {
            RandomName = $"Customer_{new Random().Next(1, 999)}";
		}

		public object Clone()
		{
			return new CustomerInputModel
			{
				Id = Id,
				FullName = FullName,
				Email = Email
			};
		}
	}
}
