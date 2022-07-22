using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAppBE.Core.Entities
{
	public class MovingAverage
	{
		public double SMA200 { get; set; }
		public double SMA50 { get; set; }

		// TODO: ExponentialMovingAverage
	}
}
