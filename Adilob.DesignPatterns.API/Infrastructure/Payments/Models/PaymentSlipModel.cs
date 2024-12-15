namespace Adilob.DesignPatterns.API.Infrastructure.Payments.Models
{
	public class PaymentSlipModel
	{
        public string BarCode { get; set; }
        public string OurNumber { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime ProcessedAt { get; set; }
        public decimal DocumentAmount { get; set; }
        public Payer Payer { get; set; }
        public Receiver Receiver { get; set; }
    }

    public class Payer
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
    }

    public class Receiver
	{
		public string Name { get; set; }
		public string Document { get; set; }
		public string Address { get; set; }
	}
}
