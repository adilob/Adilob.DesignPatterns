using Adilob.DesignPatterns.API.Application.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Orders
{
	public interface IOrderFactorySelector
	{
		IOrderAbstractFactory GetOrderAbstractFactory(OrderInputModel model);
	}
}
