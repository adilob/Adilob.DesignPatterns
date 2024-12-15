using Adilob.DesignPatterns.API.Application.Models;

namespace Adilob.DesignPatterns.API.Application.ChainOfResponsability
{
	public interface IOrderHandler
	{
		bool Handle(OrderInputModel model);
		IOrderHandler SetNext(IOrderHandler handler);
	}
}
