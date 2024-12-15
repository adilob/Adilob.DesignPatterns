using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Core.Enums;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Adapters;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	public class PaymentSlipService : IPaymentService
	{
		public bool CanProcess(PaymentMethod paymentMethod)
		{
			return paymentMethod == PaymentMethod.PaymentSlip;
		}

		private readonly IExternalPaymentSlipService _externalPaymentSlipService;

		public PaymentSlipService(IExternalPaymentSlipService externalPaymentSlipService)
		{
			_externalPaymentSlipService = externalPaymentSlipService;
		}

		public object Process(OrderInputModel model)
		{
			var paymentSlipServiceAdapter = new PaymentSlipServiceAdapter(_externalPaymentSlipService);

			var paymentSlipModel = paymentSlipServiceAdapter.GeneratePaymentoSlip(model);

			return paymentSlipModel;
		}
	}
}
