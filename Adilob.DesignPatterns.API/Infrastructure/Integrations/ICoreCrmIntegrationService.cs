using Adilob.DesignPatterns.API.Application.Models;

namespace Adilob.DesignPatterns.API.Infrastructure.Integrations
{
	public interface ICoreCrmIntegrationService
	{
		void Sync(OrderInputModel model);
	}
}
