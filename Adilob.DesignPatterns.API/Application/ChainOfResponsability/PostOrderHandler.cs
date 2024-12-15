using Adilob.DesignPatterns.API.Application.Models;

namespace Adilob.DesignPatterns.API.Application.ChainOfResponsability
{
	public class PostOrderHandler : OrderHandlerBase, IPostOrderHandler
	{
		private readonly IEnumerable<IOrderHandler> _handlers;

		public PostOrderHandler(IEnumerable<IOrderHandler> handlers)
		{
			_handlers = handlers;
		}

		public override bool Handle(OrderInputModel model)
		{
			Console.WriteLine("Processing order...");

			var validateCustomerHandler = _handlers.Where(x => x is ValidateCustomerHandler).FirstOrDefault();
			var validateStockHandler = _handlers.Where(x => x is ValidateStockHandler).FirstOrDefault();
			var checkForFraudHandler = _handlers.Where(x => x is CheckForFraudHandler).FirstOrDefault();

			validateCustomerHandler?
				.SetNext(validateStockHandler)
				.SetNext(checkForFraudHandler);

			SetNext(validateCustomerHandler);

			return base.Handle(model);
		}
	}
}
