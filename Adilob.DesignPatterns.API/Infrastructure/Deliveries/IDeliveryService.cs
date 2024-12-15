using Adilob.DesignPatterns.API.Application.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Deliveries
{
	public interface IDeliveryService
	{
		void Deliver(OrderInputModel model);
	}
}
