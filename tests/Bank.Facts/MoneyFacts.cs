using System;
using Xunit;
using Bank;
using System.Globalization;

namespace Bank.Facts
{
	public class MoneyFacts
	{
		[Fact]
		public void TestConstructorWithDecimal()
		{
			Assert.Equal(100m, new Money(100).Amount);
		}

		[Fact]
		public void TestToString()
		{
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
			Assert.Equal("$100.00", new Money(100).ToString());
		}

		[Fact]
		public void TestPlusOperator()
		{
			Assert.Equal(new Money(150m), new Money(100m) + new Money(50m));
		}

		[Fact]
		public void TestNegOperator()
		{
			Assert.Equal(new Money(50m), new Money(100m) - new Money(50m));
		}
	}
}
