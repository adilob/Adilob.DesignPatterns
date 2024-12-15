using Adilob.DesignPatterns.API.Application.ViewModels;
using Adilob.DesignPatterns.API.Core.Enums;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	// Flyweight factory
	public class PaymentMethodsFactory
	{
		private Dictionary<PaymentMethod, PaymentMethodViewModel> _paymentMethods;

		public PaymentMethodsFactory()
		{
			_paymentMethods = new Dictionary<PaymentMethod, PaymentMethodViewModel>
			{
				{ PaymentMethod.CreditCard, new PaymentMethodViewModel { PaymentMethod = PaymentMethod.CreditCard, Description = "Credit Card" } },
				{ PaymentMethod.PaymentSlip, new PaymentMethodViewModel { PaymentMethod = PaymentMethod.PaymentSlip, Description = "Payment Slip" } },
				{ PaymentMethod.PayPal, new PaymentMethodViewModel { PaymentMethod = PaymentMethod.PayPal, Description = "PayPal" } }
			};
		}

		public PaymentMethodViewModel GetPaymentMethod(PaymentMethod paymentMethod)
		{
			return _paymentMethods[paymentMethod];
		}
	}
}
