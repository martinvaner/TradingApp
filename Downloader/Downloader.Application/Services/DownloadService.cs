using Downloader.Application.Helpers;
using Downloader.Application.Repository.Interfaces;
using Downloader.Application.Services.Interfaces;
using Downloader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Downloader.Application.Services
{
	public class DownloadService : IDownloadService
	{
		private readonly ITickerRepository apiRepository;
		private readonly ITickerWritableRepository cacheRepository;
		private readonly TickerDataHelper tickerDataHelper;
		public DownloadService(ITickerRepository apiRepository, ITickerWritableRepository cacheRepository)
		{
			this.apiRepository = apiRepository;
			this.cacheRepository = cacheRepository;
			this.tickerDataHelper = new TickerDataHelper();
		}

		public async Task<Ticker> DownloadData(string symbol)
		{
			//get ticker data

			// is it cached? - get it from cache (check date)
			Ticker cachedTicker = await cacheRepository.Get(symbol);
			if(cachedTicker != null)
			{
				// check date
				if((DateTime.Now - cachedTicker.Date).Hours < 24) 
				{
					return cachedTicker;
				}
			}

			// if it is not cached or date is older then 24h - get it from api and write it to cache
			Ticker apiTicker = null;
			try
			{
				apiTicker = await apiRepository.Get(symbol);
			}
			catch(Exception e)
			{
				// TODO: maybe log here
				throw;
			}

			if (apiTicker != null)
			{
				// cache it and return
				tickerDataHelper.PrepareTickerData(ref apiTicker);
				await cacheRepository.Write(apiTicker);

				return apiTicker;
			}

			return null;
		}
	}
}
