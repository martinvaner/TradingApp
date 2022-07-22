using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAppBE.Core.Entities
{
	public class MovingAverage
	{
		public decimal SMA200 { get; set; }
		public decimal SMA50 { get; set; }

		// TODO: ExponentialMovingAverage
	}
}
