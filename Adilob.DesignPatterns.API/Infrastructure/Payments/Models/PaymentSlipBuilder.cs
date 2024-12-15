namespace Adilob.DesignPatterns.API.Infrastructure.Payments.Models
{
	public class PaymentSlipBuilder
	{
		private PaymentSlipModel _paymentSlipModel;

        public PaymentSlipBuilder()
        {
            
        }

        public PaymentSlipBuilder Start()
		{
			_paymentSlipModel = new PaymentSlipModel();
			return this;
		}

		public PaymentSlipBuilder WithBarCode(string barCode)
		{
			_paymentSlipModel.BarCode = barCode;
			return this;
		}

		public PaymentSlipBuilder WithOurNumber(string ourNumber)
		{
			_paymentSlipModel.OurNumber = ourNumber;
			return this;
		}

		public PaymentSlipBuilder WithExpiresAt(DateTime expiresAt)
		{
			_paymentSlipModel.ExpiresAt = expiresAt;
			return this;
		}

		public PaymentSlipBuilder WithProcessedAt(DateTime processedAt)
		{
			_paymentSlipModel.ProcessedAt = processedAt;
			return this;
		}

		public PaymentSlipBuilder WithDocumentAmount(decimal documentAmount)
		{
			_paymentSlipModel.DocumentAmount = documentAmount;
			return this;
		}

		public PaymentSlipBuilder WithPayer(Payer payer)
		{
			_paymentSlipModel.Payer = payer;
			return this;
		}

		public PaymentSlipBuilder WithReceiver(Receiver receiver)
		{
			_paymentSlipModel.Receiver = receiver;
			return this;
		}

		public PaymentSlipModel Build()
		{
			return _paymentSlipModel;
		}
	}
}
