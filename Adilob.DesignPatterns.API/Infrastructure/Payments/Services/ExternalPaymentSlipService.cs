using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments.Services
{
	public class ExternalPaymentSlipService : IExternalPaymentSlipService
	{
		public ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model)
		{
			return new ExternalPaymentSlipModel
			{
				bar_code = "123456789",
				number = "987654321",
				exp_date = DateTime.Now.AddDays(10),
				proc_date = DateTime.Now,
				doc_amount = 1234.56M,
				payer_name = "John Doe",
				payer_doc = "123456789",
				payer_addr = "Address Payer 1",
				receiver_name = "Mary Monroe",
				receiver_doc = "789456123",
				receiver_addr = "Address Receiver 1"
			};
		}
	}
}
