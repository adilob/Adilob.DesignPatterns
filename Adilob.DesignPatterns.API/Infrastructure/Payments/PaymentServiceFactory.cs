using Adilob.DesignPatterns.API.Core.Enums;
using Adilob.DesignPatterns.API.Infrastructure.Integrations;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Decorators;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	public class PaymentServiceFactory : IPaymentServiceFactory
	{
		private readonly IEnumerable<IPaymentService> _payments;
		private readonly ICoreCrmIntegrationService _coreCrmIntegrationService;
		private readonly IAntiFraudFacade _antiFraudFacade;

		public PaymentServiceFactory(
			IEnumerable<IPaymentService> payments,
			ICoreCrmIntegrationService coreCrmIntegrationService,
			IAntiFraudFacade antiFraudFacade)
		{
			_payments = payments;
			_coreCrmIntegrationService = coreCrmIntegrationService;
			_antiFraudFacade = antiFraudFacade;
		}

		public IPaymentService GetService(PaymentMethod paymentMethod)
		{
			IPaymentService paymentService = null;

			foreach (var payment in _payments)
			{
				if (payment.CanProcess(paymentMethod))
				{
					paymentService = payment;
					break;
				}
			}

			if (paymentService == null)
			{
				throw new InvalidOperationException("Payment method not found");
			}

			return new PaymentServiceDecorator(paymentService, _coreCrmIntegrationService, _antiFraudFacade);
		}
	}
}
