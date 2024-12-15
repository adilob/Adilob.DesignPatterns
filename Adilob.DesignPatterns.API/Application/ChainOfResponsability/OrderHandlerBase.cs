using Adilob.DesignPatterns.API.Application.Models;

namespace Adilob.DesignPatterns.API.Application.ChainOfResponsability
{
	public abstract class OrderHandlerBase
	{
		private IOrderHandler? _nextHandler;
		public virtual bool Handle(OrderInputModel model)
		{
			if (_nextHandler == null)
				return true;

			var result = _nextHandler.Handle(model);

			return result;
		}

		public IOrderHandler SetNext(IOrderHandler step)
		{
			_nextHandler = step;

			return step;
		}
	}
}
