using Adilob.DesignPatterns.API.Core.Enums;
using Adilob.DesignPatterns.API.Infrastructure.Deliveries;
using Adilob.DesignPatterns.API.Infrastructure.Payments;

namespace Adilob.DesignPatterns.API.Infrastructure.Orders
{
	public class NationalOrderAbstractFactory : IOrderAbstractFactory
	{
		private readonly IPaymentServiceFactory _paymentServiceFactory;
		private readonly IEnumerable<IDeliveryService> _deliveryServices;

		public NationalOrderAbstractFactory(IPaymentServiceFactory paymentServiceFactory, IEnumerable<IDeliveryService> deliveryServices)
		{
			_paymentServiceFactory = paymentServiceFactory;
			_deliveryServices = deliveryServices;
		}

		public IDeliveryService GetDeliveryService()
		{
			return _deliveryServices.FirstOrDefault(f => f is NationalDeliveryService);
		}

		public IPaymentService GetPaymentService(PaymentMethod paymentMethod)
		{
			return _paymentServiceFactory.GetService(paymentMethod);
		}
	}
}
