using Downloader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Application.Helpers
{
	public class TickerDataHelper
	{
		public void PrepareTickerData(ref Ticker ticker)
		{
			// I need only 200 days
			var prices = ticker.Prices.ToList();
			prices.RemoveRange(200, prices.Count - 200);

			ticker.Prices = prices.ToArray();
		}
	}
}
