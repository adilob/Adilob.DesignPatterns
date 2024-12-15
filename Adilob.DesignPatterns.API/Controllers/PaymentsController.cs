using Adilob.DesignPatterns.API.Application.ViewModels;
using Adilob.DesignPatterns.API.Core.Enums;
using Adilob.DesignPatterns.API.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Adilob.DesignPatterns.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentsController : ControllerBase
	{
		private readonly PaymentMethodsFactory _paymentMethodsFactory;

		public PaymentsController(PaymentMethodsFactory paymentMethodsFactory)
		{
			_paymentMethodsFactory = paymentMethodsFactory;
		}

		[HttpGet("payment-methods-old/{paymentMethod}")]
		public IActionResult GetPaymentMethodOld(PaymentMethod? paymentMethod)
		{
			PaymentMethodViewModel model;

			switch (paymentMethod)
			{
				case PaymentMethod.CreditCard:
					model = new PaymentMethodViewModel
					{
						PaymentMethod = PaymentMethod.CreditCard,
						Description = "Credit Card"
					};
					break;
				case PaymentMethod.PaymentSlip:
					model = new PaymentMethodViewModel
					{
						PaymentMethod = PaymentMethod.PaymentSlip,
						Description = "Payment Slip"
					};
					break;
				case PaymentMethod.PayPal:
					model = new PaymentMethodViewModel
					{
						PaymentMethod = PaymentMethod.PayPal,
						Description = "PayPal"
					};
					break;
				default:
					model = new PaymentMethodViewModel
					{
						PaymentMethod = PaymentMethod.Unknown,
						Description = "Unknown"
					};
					break;
			}

			return Ok(model);
		}

		[HttpGet("payment-methods/{paymentMethod}")]
		public IActionResult GetPaymentMethod(PaymentMethod? paymentMethod)
		{
			if (!paymentMethod.HasValue || paymentMethod == PaymentMethod.Unknown)
			{
				return BadRequest();
			}

			PaymentMethodViewModel model = _paymentMethodsFactory.GetPaymentMethod(paymentMethod.Value);

			return Ok(model);
		}
	}
}
