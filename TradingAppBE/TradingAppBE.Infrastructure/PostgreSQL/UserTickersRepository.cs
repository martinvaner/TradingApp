using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Infrastructure.EF;
using TrradingAppBE.Application.Repository.Interfaces;

namespace TradingAppBE.Infrastructure.PostgreSQL
{
	public class UserTickersRepository : IUserTickersRepository
	{
		private readonly TickersContext tickersContext;

		public UserTickersRepository(TickersContext tickersContext)
		{
			this.tickersContext = tickersContext;
		}

		public async Task<IEnumerable<string>> GetUserTickers(string username)
		{
			return await tickersContext.Users.Where(x => x.Username.Equals(username))
				.SelectMany(x => x.UserTickers.Select(y => y.Ticker.Symbol))
				.ToListAsync();
		}
	}
}
