using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TrradingAppBE.Application.Repository.Interfaces;

namespace TradingAppBE.Infrastructure.Redis
{
	public class RedisRepository : ITickerRepository
	{
		private readonly IDistributedCache distributedCache;

		public RedisRepository(IDistributedCache distributedCache)
		{
			this.distributedCache = distributedCache;
		}

		public async Task<Ticker> Get(string symbol)
		{
			string value = await distributedCache.GetStringAsync(symbol);
			if (string.IsNullOrEmpty(value)) return null; // TODO: rewrite to exception

			Ticker ticker = JsonSerializer.Deserialize<Ticker>(value);

			return ticker;
		}
	}
}
