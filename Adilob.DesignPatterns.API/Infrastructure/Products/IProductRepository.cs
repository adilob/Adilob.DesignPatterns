﻿namespace Adilob.DesignPatterns.API.Infrastructure.Products
{
	public interface IProductRepository
	{
		bool HasStock(Dictionary<Guid, int> items);
	}
}
