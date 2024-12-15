using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Customers;

namespace Adilob.DesignPatterns.API.Application.ChainOfResponsability
{
	public class ValidateCustomerHandler : OrderHandlerBase, IOrderHandler
	{
		private readonly ICustomerRepository _customerRepository;

		public ValidateCustomerHandler(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public override bool Handle(OrderInputModel model)
		{
			Console.WriteLine("Validating customer...");

			var customer = _customerRepository.GetCustomerById(model.Customer.Id);
			var customerAllowedToBuy = customer.IsAllowedToBuy();

			if (!customerAllowedToBuy)
				return false;

			return base.Handle(model);
		}
	}
}
