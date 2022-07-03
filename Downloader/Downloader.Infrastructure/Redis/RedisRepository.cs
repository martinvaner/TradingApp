using Downloader.Application.Repository.Interfaces;
using Downloader.Core.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Downloader.Infrastructure.Redis
{
	public class RedisRepository : ITickerWritableRepository
	{
		private readonly IDistributedCache distributedCache;

		public RedisRepository(IDistributedCache distributedCache)
		{
			this.distributedCache = distributedCache;
		}

		public async Task<Ticker> Get(string tickerName)
		{
			string value = await distributedCache.GetStringAsync(tickerName);
			if (string.IsNullOrEmpty(value)) return null; // TODO: rewrite to exception

			Ticker ticker = new Ticker()
			{
				Symbol = tickerName,
				Prices = JsonSerializer.Deserialize<Price[]>(value)
			};

			return ticker;
		}

		public async Task Write(Ticker ticker)
		{
			string s = JsonSerializer.Serialize<Price[]>(ticker.Prices);
			await distributedCache.SetStringAsync(ticker.Symbol, JsonSerializer.Serialize<Price[]>(ticker.Prices));
		}
	}
}
