using Adilob.DesignPatterns.API.Infrastructure.Customers;
using Adilob.DesignPatterns.API.Infrastructure.Proxies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Adilob.DesignPatterns.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IMemoryCache _memoryCache;
		private readonly CustomerRepositoryProxy _customerRepositoryProxy;

		public CustomersController(
			ICustomerRepository customerRepository,
			IMemoryCache memoryCache,
			CustomerRepositoryProxy customerRepositoryProxy)
		{
			_customerRepository = customerRepository;
			_memoryCache = memoryCache;
			_customerRepositoryProxy = customerRepositoryProxy;
		}

		[HttpGet("get-blocked-customers-old")]
		public IActionResult GetBlockedCustomersOld()
		{
			if (HttpContext.Request.Headers["x-role"] != "Admin")
				return Unauthorized();

			var blockedCustomers = _memoryCache.GetOrCreate("blocked-customers", entry =>
			{
				return _customerRepository.GetBlockedCustomers();
			});

			return Ok(blockedCustomers);
		}

		[HttpGet("get-blocked-customers")]
		public IActionResult GetBlockedCustomers()
		{
			var blockedCustomers = _customerRepositoryProxy.GetBlockedCustomers();

			if (blockedCustomers is null)
				return Unauthorized();

			return Ok(blockedCustomers);
		}
	}
}
