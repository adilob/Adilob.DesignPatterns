using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Core.Enums;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments
{
	public interface IPaymentService
	{
		bool CanProcess(PaymentMethod paymentMethod);
		object Process(OrderInputModel model);
	}
}
