using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;

namespace TrradingAppBE.Application.Services.Interfaces
{
	public interface IAnalyticsService
	{
		Analytics CalculateAnalytics(Ticker ticker);
	}
}
