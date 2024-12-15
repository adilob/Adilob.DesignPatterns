using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	public interface IExternalPaymentSlipService
	{
		ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model);
	}
}
