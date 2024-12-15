using Adilob.DesignPatterns.API.Core.Enums;
using Adilob.DesignPatterns.API.Infrastructure.Deliveries;
using Adilob.DesignPatterns.API.Infrastructure.Payments;

namespace Adilob.DesignPatterns.API.Infrastructure.Orders
{
	public interface IOrderAbstractFactory
	{
		IPaymentService GetPaymentService(PaymentMethod paymentMethod);
		IDeliveryService GetDeliveryService();
	}
}
