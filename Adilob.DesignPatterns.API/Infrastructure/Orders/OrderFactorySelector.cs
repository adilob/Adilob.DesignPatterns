using Adilob.DesignPatterns.API.Application.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Orders
{
	public class OrderFactorySelector : IOrderFactorySelector
	{
		private readonly IEnumerable<IOrderAbstractFactory> _orderAbstractFactories;

		public OrderFactorySelector(IEnumerable<IOrderAbstractFactory> orderAbstractFactories)
		{
			_orderAbstractFactories = orderAbstractFactories;
		}

		public IOrderAbstractFactory GetOrderAbstractFactory(OrderInputModel model)
		{
			if (model.IsInternational)
			{
				return _orderAbstractFactories.FirstOrDefault(f => f is InternationalOrderAbstractFactory);
			}
			else
			{
				return _orderAbstractFactories.FirstOrDefault(f => f is NationalOrderAbstractFactory);
			}
		}
	}
}
