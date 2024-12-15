using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Payments.Adapters
{
	public class PaymentSlipServiceAdapter
	{
		private readonly IExternalPaymentSlipService _externalPaymentSlipService;

		public PaymentSlipServiceAdapter(IExternalPaymentSlipService externalPaymentSlipService)
		{
			_externalPaymentSlipService = externalPaymentSlipService;
		}

		public PaymentSlipModel GeneratePaymentoSlip(OrderInputModel model)
		{
			var externalModel = _externalPaymentSlipService.GeneratePaymentSlip(model);

			var builder = new PaymentSlipBuilder();

			var paymentSlipModel = builder
				.Start()
				.WithBarCode(externalModel.bar_code)
				.WithOurNumber(externalModel.number)
				.WithExpiresAt(externalModel.exp_date)
				.WithProcessedAt(externalModel.proc_date)
				.WithDocumentAmount(externalModel.doc_amount)
				.WithPayer(new Payer
				{
					Name = externalModel.payer_name,
					Document = externalModel.payer_doc,
					Address = externalModel.payer_addr
				})
				.WithReceiver(new Receiver
				{
					Name = externalModel.receiver_name,
					Document = externalModel.receiver_doc,
					Address = externalModel.receiver_addr
				})
				.Build();

			return paymentSlipModel;
		}
	}
}
