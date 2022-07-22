using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrradingAppBE.Application.Algorithms.Interfaces
{
	public interface IMovingAverageAlgorithm
	{
		double Calculate(int numberOfDays, double[] prices);
	}
}
