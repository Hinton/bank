using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
	public class Money : IComparable<Money>
	{

		private readonly decimal _amount;

		public decimal Amount {
			get {
				return _amount;
			}
		}

		public Money(decimal amount)
		{
			this._amount = amount;
		}

		public Money() : this(0m)
		{
		}

		public override String ToString()
		{
			return _amount.ToString("C");
		}


		public static Money operator +(Money a, Money b)
		{
			return new Money(a.Amount + b.Amount);
		}

		public static Money operator -(Money a, Money b)
		{
			return new Money(a.Amount - b.Amount);
		}

		public static bool operator <(Money a, Money b)
		{
			return a.CompareTo(b) < 0;
		}

		public static bool operator >(Money a, Money b)
		{
			return a.CompareTo(b) > 0;
		}

		public override bool Equals(object obj)
		{
			var item = obj as Money;

			if (item == null)
			{
				return false;
			}

			return Amount.Equals(item.Amount);
		}

		public int CompareTo(Money other)
		{
			return Amount.CompareTo(other.Amount);
		}
	}
}
