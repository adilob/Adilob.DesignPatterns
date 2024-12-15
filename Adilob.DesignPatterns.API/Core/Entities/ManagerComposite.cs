namespace Adilob.DesignPatterns.API.Core.Entities
{
	public class ManagerComposite : EmployeeComponent
	{
		private readonly List<EmployeeComponent> _children;
		public ManagerComposite(string name, string role, decimal expenses) : base(name, role, expenses)
		{
			_children = new List<EmployeeComponent>();
		}

		public override decimal GetExpenses()
		{
			return _children.Sum(c => c.GetExpenses()) + Expenses;
		}

		public void Add(EmployeeComponent employee)
		{
			_children.Add(employee);
		}

		public void Remove(EmployeeComponent employee)
		{
			_children.Remove(employee);
		}
	}
}
