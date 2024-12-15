using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	public interface IPaymentFraudCheckService
	{
		bool IsFraud(OrderInputModel model);
		bool IsFraudV2(decimal totalAmount, Guid customerId, string customerName, string document);
		bool IsFraudV2UsingCommand(FraudCheckModel command);
	}
}
