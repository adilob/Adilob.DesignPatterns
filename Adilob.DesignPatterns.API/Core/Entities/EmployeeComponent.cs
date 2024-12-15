namespace Adilob.DesignPatterns.API.Core.Entities
{
	public abstract class EmployeeComponent
	{
		protected EmployeeComponent(string name, string role, decimal expenses)
		{
			Name = name;
			Role = role;
			Expenses = expenses;
		}

		public string Name { get; private set; }
        public string Role { get; private set; }
        public decimal Expenses { get; set; }
        public abstract decimal GetExpenses();
	}
}
