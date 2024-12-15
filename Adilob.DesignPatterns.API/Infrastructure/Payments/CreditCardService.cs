using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Core.Enums;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	public class CreditCardService : IPaymentService
	{
		public bool CanProcess(PaymentMethod paymentMethod)
		{
			return paymentMethod == PaymentMethod.CreditCard;
		}

		public object Process(OrderInputModel model)
		{
			return "Credit card information";
		}
	}
}
