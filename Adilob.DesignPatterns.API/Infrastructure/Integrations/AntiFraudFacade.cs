using Newtonsoft.Json;
using System.Text;

namespace Adilob.DesignPatterns.API.Infrastructure.Integrations
{
	public class AntiFraudFacade : IAntiFraudFacade
	{
		public AntiFraudResultModel Check(AntiFraudModel model)
		{
			var json = JsonConvert.SerializeObject(model);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var url = "http://localhost:5000/api/antifraud";

			using var client = new HttpClient();

			var antiFraudRequest = client.PostAsync(url, content).Result;
			var antiFraudResultString = antiFraudRequest.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<AntiFraudResultModel>(antiFraudResultString);
		}
	}
}
