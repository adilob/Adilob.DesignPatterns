using Adilob.DesignPatterns.API.Core.Enums;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	public interface IPaymentServiceFactory
	{
		IPaymentService GetService(PaymentMethod paymentMethod);
	}
}
