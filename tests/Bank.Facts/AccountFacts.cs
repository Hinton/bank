using System;
using Xunit;

namespace Bank.Facts
{
	public class AccountFacts
	{

		public class TransferMethod
		{
			[Fact]
			public void ValidTransfer()
			{
				Account a = new Account(new Money(200m));
				Account b = new Account();

				a.Transfer(b, new Money(200m));

				Assert.Equal(new Money(0m), a.Balance);
				Assert.Equal(new Money(200m), b.Balance);
			}

			[Fact]
			public void InsufficientFunds()
			{
				Account a = new Account(new Money(200m));
				Account b = new Account();

				Assert.Throws<InsufficientFundsException>(() => a.Transfer(b, new Money(300m)));

				Assert.Equal(new Money(200m), a.Balance);
				Assert.Equal(new Money(0m), b.Balance);
			}

			[Fact]
			public void NegativeAmount()
			{
				Account a = new Account(new Money(200m));
				Account b = new Account();

				Assert.Throws<InvalidAmountException>(() => a.Transfer(b, new Money(-100m)));

				Assert.Equal(new Money(200m), a.Balance);
				Assert.Equal(new Money(0m), b.Balance);
			}

		}


	}
}
