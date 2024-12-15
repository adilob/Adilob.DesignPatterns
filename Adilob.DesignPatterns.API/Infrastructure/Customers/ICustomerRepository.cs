using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Core.Entities;

namespace Adilob.DesignPatterns.API.Infrastructure.Customers
{
	public interface ICustomerRepository
	{
		IEnumerable<CustomerInputModel> GetBlockedCustomers();
		Customer GetCustomerById(Guid id);
	}
}
