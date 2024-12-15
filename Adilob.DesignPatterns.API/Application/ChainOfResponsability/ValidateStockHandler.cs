using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Infrastructure.Products;

namespace Adilob.DesignPatterns.API.Application.ChainOfResponsability
{
	public class ValidateStockHandler : OrderHandlerBase, IOrderHandler
	{
		private readonly IProductRepository _productRepository;

		public ValidateStockHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public override bool Handle(OrderInputModel model)
		{
			Console.WriteLine("Validating stock...");

			var itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
			var hasStock = _productRepository.HasStock(itemsDictionary);

			if (!hasStock)
				return false;

			return base.Handle(model);
		}
	}
}
