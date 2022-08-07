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
		private readonly IUserTickersRepository userTickersRepository;

		public DataService(ITickerRepository redisRepository, IDownloaderApiRepository downloader,
				IAnalyticsService analyticsService, IUserTickersRepository userTickersRepository)
		{
			this.redisRepository = redisRepository;
			this.downloader = downloader;
			this.analyticsService = analyticsService;
			this.userTickersRepository = userTickersRepository;
		}

		public async Task<IEnumerable<Ticker>> CreateUserTickers(string username, string[] symbols)
		{
			// TODO: check if are unregistered ?

			try
			{
				// post to downloader
				var newTickers = await downloader.Create(symbols);
				if (newTickers == null)
				{
					// TODO better exception
					throw new Exception("Couldn't get tickers");
				}

				foreach (var ticker in newTickers)
				{
					ticker.Analytics = analyticsService.CalculateAnalytics(ticker);
				}

				// connect tickers to username
				await userTickersRepository.CreateUserTickers(username, symbols);


				return newTickers;
			}
			catch(Exception e)
			{
				// log here
				// catch better exception
				throw;
			}
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

		public async Task<IEnumerable<Ticker>> GetUserTickers(string username)
		{
			List<Ticker> tickers = new List<Ticker>();

			var userTickers = await userTickersRepository.GetUserTickers(username);

			foreach(var userTicker in userTickers)
			{
				try
				{
					tickers.Add(await this.GetTickerData(userTicker));
				}
				catch(Exception e)
				{
					// intentionally blank - just continue work
				}

			}

			return tickers;
		}

		public async Task RemoveUserTickers(string username, string[] symbols)
		{
			//remove connection between username and symbols
			// if there are no users, using symbol, remove in redis and postgre
			
			try 
			{
				await userTickersRepository.RemoveUserTickers(username, symbols);

				foreach (var symbol in symbols)
				{
					if (!await userTickersRepository.ExistsTickerConnection(symbol))
					{
						// remove from postgre and redis
						await userTickersRepository.RemoveTicker(symbol);

						// TODO: dont do it here - send it to downloader to unsubscribe
						await redisRepository.Remove(symbol);
					}
				}
			}
			catch(Exception e)
			{
				// left blank for now
			}
			
		}
	}
}
