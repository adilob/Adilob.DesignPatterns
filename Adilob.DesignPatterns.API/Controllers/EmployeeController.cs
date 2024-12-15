using Adilob.DesignPatterns.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Adilob.DesignPatterns.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		[HttpGet("get-expenses")]
		public IActionResult GetExpenses()
		{
			var composite = new ManagerComposite("John Doe", "Manager", 100000);

			composite.Add(new Employee("Jane Doe", "Developer", 50000));
			composite.Add(new Employee("Alice Doe", "Developer", 60000));

			var composite2 = new ManagerComposite("Bob Doe", "Manager", 120000);

			composite.Add(composite2);

			composite2.Add(new Employee("Charlie Doe", "Developer", 70000));
			composite2.Add(new Employee("Eve Doe", "Developer", 80000));

			return Ok(new
			{
				expensesDirector = composite.GetExpenses(),
				expensesManager = composite2.GetExpenses()
			});
		}
	}
}
