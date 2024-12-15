using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Core.Enums;
using Adilob.DesignPatterns.API.Infrastructure.Integrations;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments.Decorators
{
	public class PaymentServiceDecorator : IPaymentService
	{
		private readonly IPaymentService _paymentService;
		private readonly ICoreCrmIntegrationService _coreCrmIntegrationService;
		private readonly IAntiFraudFacade _antiFraudFacade;

		public PaymentServiceDecorator(
			IPaymentService paymentService,
			ICoreCrmIntegrationService coreCrmIntegrationService,
			IAntiFraudFacade antiFraudFacade)
		{
			_paymentService = paymentService;
			_coreCrmIntegrationService = coreCrmIntegrationService;
			_antiFraudFacade = antiFraudFacade;
		}

		public bool CanProcess(PaymentMethod paymentMethod)
		{
			return paymentMethod == PaymentMethod.PaymentSlip;
		}

		public object Process(OrderInputModel model)
		{
			var antiFraudModel = new AntiFraudModel(model.Customer.Document, model.TotalPrice);
			var antiFraudResult = _antiFraudFacade.Check(antiFraudModel);

			if (antiFraudResult == null || antiFraudResult.CheckResult)
				throw new InvalidOperationException(antiFraudResult.Comments);

			var result = _paymentService.Process(model);

			_coreCrmIntegrationService.Sync(model);

			return result;
		}
	}
}
