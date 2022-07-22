using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrradingAppBE.Application.Algorithms.Interfaces
{
	public interface IMovingAverageAlgorithm
	{
		decimal Calculate(int numberOfDays, decimal[] prices);
	}
}
