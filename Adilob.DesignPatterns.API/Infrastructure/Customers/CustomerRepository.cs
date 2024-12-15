using Adilob.DesignPatterns.API.Application.Models;
using Adilob.DesignPatterns.API.Core.Entities;

namespace Adilob.DesignPatterns.API.Infrastructure.Customers
{
	public class CustomerRepository : ICustomerRepository
	{
		public IEnumerable<CustomerInputModel> GetBlockedCustomers()
		{
			return new List<CustomerInputModel>() {
				new CustomerInputModel() { FullName = "Customer 1", Document = "12345678901" },
				new CustomerInputModel() { FullName = "Customer 2", Document = "12345678902" },
				new CustomerInputModel() { FullName = "Customer 3", Document = "12345678903" },
				new CustomerInputModel() { FullName = "Customer 4", Document = "12345678904" },
				new CustomerInputModel() { FullName = "Customer 5", Document = "12345678905" }
			};
		}

		public Customer GetCustomerById(Guid id)
		{
			return new Customer(birthDate: new DateTime(1985, 10, 10), status: CustomerStatus.Active, email: "adilobertoncello@gmail.com", fullName: "Adilo Bertoncello");
		}
	}
}
