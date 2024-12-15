namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	public interface IExternalPaymentSlipModel
	{
		string bar_code { get; set; }
		string number { get; set; }
		DateTime exp_date { get; set; }
		DateTime proc_date { get; set; }
		decimal doc_amount { get; set; }
		string payer_name { get; set; }
		string payer_doc { get; set; }
		string payer_addr { get; set; }
		string receiver_name { get; set; }
		string receiver_doc { get; set; }
		string receiver_addr { get; set; }
	}
}
