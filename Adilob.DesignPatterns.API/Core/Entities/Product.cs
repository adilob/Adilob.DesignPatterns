using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Adilob.DesignPatterns.API.Core.Entities
{
	public abstract class OldItem
	{
        public string Title { get; set; }
        public decimal PricePerUnit { get; set; }
		public abstract decimal GetTotalPrice(decimal units);
	}

	public class OldProduct : OldItem
	{
        public string Category { get; set; }

        public override decimal GetTotalPrice(decimal units)
		{
			throw new NotImplementedException();
		}
	}

	public class OldFood : OldItem
	{
        public string NutritionLabel { get; set; }

        public override decimal GetTotalPrice(decimal units)
		{
			throw new NotImplementedException();
		}
	}

	public class ProductMeasuredByQuantity : OldItem
	{
		public override decimal GetTotalPrice(decimal units)
		{
			return PricePerUnit * units;
		}
	}

	public class ProductMeasuredByKg : OldItem
	{
		public override decimal GetTotalPrice(decimal units)
		{
			return PricePerUnit * units;
		}
	}

	public class FoodMeasuredByQuantity : OldItem
	{
		public override decimal GetTotalPrice(decimal units)
		{
			return PricePerUnit * units;
		}
	}

	public class FoodMeasuredByKg : OldItem
	{
		public override decimal GetTotalPrice(decimal units)
		{
			return PricePerUnit * units;
		}
	}

	//Bridge

	public abstract class Item
	{
		protected readonly IUnit _unit;

		protected Item(IUnit unit)
		{
			_unit = unit;
		}

		public string Title { get; set; }
		public decimal PricePerUnit { get; set; }
		public abstract decimal GetTotalPrice(decimal units);
	}

	public interface IUnit
	{
		decimal Minimum { get; }
		decimal Maximum { get; }
		bool Validate(decimal units);
	}

	public class Kg : IUnit
	{
		public decimal Minimum { get; set; }

		public decimal Maximum => throw new NotImplementedException();

		public bool Validate(decimal units)
		{
			return units < 10;
		}
	}

	public class Quantity : IUnit
	{
		public decimal Minimum => throw new NotImplementedException();

		public decimal Maximum => throw new NotImplementedException();

		public bool Validate(decimal units)
		{
			if (units % 1 != 0)
				return false;

			if (Minimum > units || Maximum < units)
				return false;

			return true;
		}
	}

	public class Product : Item
	{
		public Product(IUnit unit) : base(unit)
		{
		}

		public override decimal GetTotalPrice(decimal units)
		{
			throw new NotImplementedException();
		}
	}

	public class Food : Item
	{
		public Food(IUnit unit) : base(unit)
		{
		}

		public override decimal GetTotalPrice(decimal units)
		{
			if (!_unit.Validate(units))
				throw new ArgumentException("Invalid units");

			return PricePerUnit * units;
		}
	}
}
