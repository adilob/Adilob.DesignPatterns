using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments.Services
{
	public class PaymentFraudCheckService : IPaymentFraudCheckService
	{
		public bool IsFraud(OrderInputModel model)
		{
			return false;
		}

		public bool IsFraudV2(decimal totalAmount, Guid customerId, string customerName, string document)
		{
			return false;
		}

		public bool IsFraudV2UsingCommand(FraudCheckModel command)
		{
			return false;
		}
	}
}
