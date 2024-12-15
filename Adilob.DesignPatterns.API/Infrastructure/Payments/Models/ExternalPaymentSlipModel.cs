namespace Adilob.DesignPatterns.API.Infrastructure.Payments.Models
{
	public class ExternalPaymentSlipModel : IExternalPaymentSlipModel
	{
		public string bar_code { get; set; }
		public string number { get; set; }
		public DateTime exp_date { get; set; }
		public DateTime proc_date { get; set; }
		public decimal doc_amount { get; set; }
		public string payer_name { get; set; }
		public string payer_doc { get; set; }
		public string payer_addr { get; set; }
		public string receiver_name { get; set; }
		public string receiver_doc { get; set; }
		public string receiver_addr { get; set; }
	}
}
