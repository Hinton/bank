using System;
using Xunit;
using Bank;
using System.Globalization;
using Ploeh.AutoFixture.Xunit2;

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

		[Theory, AutoData]
		public void TestNegOperator(decimal a, decimal b)
		{
			Assert.Equal(new Money(a - b), new Money(a) - new Money(b));
		}

	    [Theory, AutoData]
	    public void Equals(decimal amount)
	    {
	        Assert.Equal(new Money(amount), new Money(amount));
	    }
	}
}
