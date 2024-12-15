using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Core.Entities;
using Adilob.DesignPatterns.API.Infrastructure.Customers;
using Microsoft.Extensions.Caching.Memory;

namespace Adilob.DesignPatterns.API.Infrastructure.Proxies
{
	public class CustomerRepositoryProxy : ICustomerRepository
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IMemoryCache _memoryCache;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CustomerRepositoryProxy(
			ICustomerRepository customerRepository, 
			IMemoryCache memoryCache, 
			IHttpContextAccessor httpContextAccessor)
		{
			_customerRepository = customerRepository;
			_memoryCache = memoryCache;
			_httpContextAccessor = httpContextAccessor;
		}

		public IEnumerable<CustomerInputModel> GetBlockedCustomers()
		{
			var httpContext = _httpContextAccessor.HttpContext;

			if (httpContext is null)
				return null;

			if (httpContext.Request.Headers["x-role"] != "Admin")
				return null;

			var blockedCustomers = _memoryCache.GetOrCreate("blocked-customers", entry =>
			{
				return _customerRepository.GetBlockedCustomers();
			});

			return blockedCustomers;
		}

		public Customer GetCustomerById(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
