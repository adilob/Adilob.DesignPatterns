using Adilob.DesignPatterns.API.Application.ChainOfResponsability;
using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Customers;
using Adilob.DesignPatterns.API.Infrastructure.Orders;
using Adilob.DesignPatterns.API.Infrastructure.Payments;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Models;
using Adilob.DesignPatterns.API.Infrastructure.Products;
using Microsoft.AspNetCore.Mvc;

namespace Adilob.DesignPatterns.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IPaymentServiceFactory _paymentServiceFactory;
		private readonly IOrderFactorySelector _orderFactorySelector;

		public OrdersController(IPaymentServiceFactory paymentServiceFactory, IOrderFactorySelector orderFactorySelector)
		{
			_paymentServiceFactory = paymentServiceFactory;
			_orderFactorySelector = orderFactorySelector;
		}

		[HttpPost]
		public IActionResult Post([FromBody] OrderInputModel inputModel)
		{
			IOrderAbstractFactory orderAbstractFactory = _orderFactorySelector.GetOrderAbstractFactory(inputModel);

			orderAbstractFactory
				.GetDeliveryService()
				.Deliver(inputModel);

			var result = orderAbstractFactory
				.GetPaymentService(inputModel.PaymentInfo.PaymentMethod)
				.Process(inputModel);

			var customerCopy = inputModel.Customer.Clone() as CustomerInputModel;

			Console.WriteLine(Application.Configurations.BusinessHours.Instance.ToString());

			return Ok(customerCopy);
		}

		[HttpPost("not-using-chain")]
		public IActionResult Post(
			OrderInputModel model,
			[FromServices] IProductRepository productRepository,
			[FromServices] IPaymentFraudCheckService fraudCheckService,
			[FromServices] ICustomerRepository customerRepository)
		{
			var itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
			var hasStock = productRepository.HasStock(itemsDictionary);

			if (!hasStock)
				return BadRequest();

			var customer = customerRepository.GetCustomerById(model.Customer.Id);
			var customerAllowedToBuy = customer.IsAllowedToBuy();

			if (!customerAllowedToBuy)
				return BadRequest();

			var isFraud = fraudCheckService.IsFraud(model);

			if (isFraud)
				return BadRequest();

			return NoContent();
		}

		[HttpPost("using-chain")]
		public IActionResult PostWithChain(
			OrderInputModel model,
			[FromServices] IPostOrderHandler postOrderHandler)
		{
			bool success = postOrderHandler.Handle(model);

			if (!success)
				return BadRequest();

			return NoContent();
		}

		[HttpPost("not-using-command")]
		public IActionResult NotPostUsingCommand(
			OrderInputModel model,
			[FromServices] IPaymentFraudCheckService fraudCheckService)
		{
			var total = model.Items.Sum(i => i.Price * i.Quantity);

			var isFraud = fraudCheckService.IsFraudV2(total, model.Customer.Id, model.Customer.FullName, model.Customer.Document);

			if (isFraud)
				return BadRequest();

			var message = new
			{
				total,
				customerId = model.Customer.Id,
				fullName = model.Customer.FullName,
				document = model.Customer.Document
			};

			// Chamar um serviço de mensageria para enviar esse objeto como JSON
			// Guardar um log desse objeto

			return NoContent();
		}

		[HttpPost("using-command")]
		public IActionResult PostUsingCommand(
			OrderInputModel model,
			[FromServices] IPaymentFraudCheckService fraudCheckService)
		{
			var total = model.Items.Sum(i => i.Price * i.Quantity);
			var command = new FraudCheckModel(total, model.Customer.Id, model.Customer.FullName, model.Customer.Document);

			var isFraud = fraudCheckService.IsFraudV2UsingCommand(command);

			if (isFraud)
				return BadRequest();

			// Chamar um serviço de mensageria para enviar esse objeto como JSON
			// Guardar um log desse objeto

			return NoContent();
		}
	}
}
