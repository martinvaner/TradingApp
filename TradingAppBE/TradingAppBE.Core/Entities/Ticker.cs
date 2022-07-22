using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAppBE.Core.Entities
{
	public class Ticker
	{
		public string Symbol { get; set; }
		public DateTime Date { get; set; }
		public Price[] Prices { get; set; }
		public Analytics Analytics { get; set; }
	}
}
