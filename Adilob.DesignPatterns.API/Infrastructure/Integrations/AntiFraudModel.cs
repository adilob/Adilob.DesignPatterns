namespace Adilob.DesignPatterns.API.Infrastructure.Integrations
{
	public class AntiFraudModel
	{
		public AntiFraudModel(string document, decimal amount)
		{
			Document = document;
			Amount = amount;
		}

		public string Document { get; set; }
        public decimal Amount { get; set; }
    }
}
