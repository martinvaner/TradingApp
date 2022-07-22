using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrradingAppBE.Application.Algorithms.Interfaces;

namespace TrradingAppBE.Application.Algorithms
{
	/// <summary>
	/// Simple moving average
	/// </summary>
	public class SMA : IMovingAverageAlgorithm
	{
		public double Calculate(int numberOfDays, double[] prices)
		{
			if(prices.Length < numberOfDays)
			{
				// TODO: throw better exception?
				throw new Exception("Not enough data provided.");
			}

			double sum = 0;
			for(int i = 0; i < numberOfDays; i++)
			{
				sum += prices[i];
			}

			return sum / numberOfDays;
		}
	}
}
