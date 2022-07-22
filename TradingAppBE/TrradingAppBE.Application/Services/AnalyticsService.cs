using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TrradingAppBE.Application.Algorithms.Interfaces;
using TrradingAppBE.Application.Services.Interfaces;

namespace TrradingAppBE.Application.Services
{
	public class AnalyticsService : IAnalyticsService
	{
		private readonly IMovingAverageAlgorithm movingAverageAlgorithm;

		public AnalyticsService(IMovingAverageAlgorithm movingAverageAlgorithm)
		{
			this.movingAverageAlgorithm = movingAverageAlgorithm;
		}

		public Analytics CalculateAnalytics(Ticker ticker)
		{
			decimal[] prices = ticker.Prices.Select(x => x.Close).ToArray();
			decimal sma200 = movingAverageAlgorithm.Calculate(200, prices);
			decimal sma50 = movingAverageAlgorithm.Calculate(50, prices);

			Analytics analytics = new Analytics();
			analytics.MovingAverage = new MovingAverage()
			{
				SMA200 = sma200,
				SMA50 = sma50
			};

			return analytics;
		}
	}
}
