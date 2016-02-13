using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
	public class Account
	{

		private Money _balance;

		public Money Balance
		{
			get
			{
				return _balance;
			}
		}

		public Account(Money balance)
		{
			this._balance = balance;
		}

		public Account() : this(new Money()) { }

		public bool Transfer(Account a, Money amount)
		{
			if (_balance < amount)
			{
				throw new InsufficientFundsException();
			}

			if (amount.Amount < 0)
			{
				throw new InvalidAmountException();
			}

			// Remove balance from this account
			_balance = _balance - amount;

			// Add balance to Account a
			a._balance = a._balance + amount;

			return true;
		}

		public bool Withdraw(Money amount)
		{
			// TODO: This should generate a transaction
			if (_balance < amount)
			{
				throw new InsufficientFundsException();
			}

			if (amount.Amount < 0)
			{
				throw new InvalidAmountException();
			}

			// Remove balance from this account
			_balance = _balance - amount;

			return true;
		}
	}
}
