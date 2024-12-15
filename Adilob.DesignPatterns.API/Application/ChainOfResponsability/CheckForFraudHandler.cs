using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Payments;

namespace Adilob.DesignPatterns.API.Application.ChainOfResponsability
{
	public class CheckForFraudHandler : OrderHandlerBase, IOrderHandler
	{
		private readonly IPaymentFraudCheckService _fraudCheckService;

		public CheckForFraudHandler(IPaymentFraudCheckService fraudCheckService)
		{
			_fraudCheckService = fraudCheckService;
		}

		public override bool Handle(OrderInputModel model)
		{
			Console.WriteLine("Checking for fraud...");

			var isFraud = _fraudCheckService.IsFraud(model);

			if (isFraud)
				return false;

			return base.Handle(model);
		}
	}
}
