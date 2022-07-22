using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrradingAppBE.Application.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace TradingAppBE.Application.UnitTests
{
	public class SMATests
	{
		private readonly SMA sma;
		private readonly ITestOutputHelper outputHelper;

		public SMATests(ITestOutputHelper outputHelper)
		{
			this.sma = new SMA();
			this.outputHelper = outputHelper;
		}

		[Theory]
		[MemberData(nameof(TestData))]
		public void CalculateShouldEqualTheory(decimal expected, int numberOfDays, params decimal[] prices) 
		{
			decimal result = sma.Calculate(numberOfDays, prices);
			outputHelper.WriteLine($"Result: {result}");
			Assert.Equal(expected, result);
		}


		public static IEnumerable<object[]> TestData()
		{
			yield return new object[] { 34.68, 25, new decimal[] { 10, 70, 78, 52, 65, 89, 78, 41, 52, 3, 6, 5, 8, 7, 44, 12, 56, 23, 68, 52, 36, 5, 2, 1, 4 } };
			yield return new object[] { 0, 4, new decimal[] { 0, 0, 0, 0 } };
		}
	}
}
