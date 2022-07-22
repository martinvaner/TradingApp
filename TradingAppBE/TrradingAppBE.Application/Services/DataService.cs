using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TrradingAppBE.Application.Algorithms.Interfaces;
using TrradingAppBE.Application.Repository.Interfaces;
using TrradingAppBE.Application.Services.Interfaces;

namespace TrradingAppBE.Application.Services
{
	public class DataService : IDataService
	{
		private readonly ITickerRepository redisRepository;
		private readonly IDownloaderApiRepository downloader;
		private readonly IAnalyticsService analyticsService;

		public DataService(ITickerRepository redisRepository, IDownloaderApiRepository downloader, IAnalyticsService analyticsService)
		{
			this.redisRepository = redisRepository;
			this.downloader = downloader;
			this.analyticsService = analyticsService;
		}

		public async Task<Ticker> GetTickerData(string symbol)
		{
			// try get it from redis
			Ticker ticker = await this.redisRepository.Get(symbol);
			if (ticker != null)
			{
				ticker.Analytics = analyticsService.CalculateAnalytics(ticker);
				return ticker;
			}
			// if it is not there, call downloader to get it - getData/{symbol} endpoint
			ticker = await downloader.Get(symbol);
			if (ticker == null)
			{
				return null; // TODO: rework to exception
				// throw exception and log
			}

			ticker.Analytics = analyticsService.CalculateAnalytics(ticker);
			return ticker;
		}
	}
}
