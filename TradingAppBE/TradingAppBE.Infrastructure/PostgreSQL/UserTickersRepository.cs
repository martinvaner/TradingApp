using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Infrastructure.EF;
using TradingAppBE.Infrastructure.EF.DTOs;
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

		public async Task CreateUserTickers(string username, string[] symbols)
		{
			// create tickers
			await this.CreateTickers(symbols);

			var user = await tickersContext.Users.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();
			if(user == null)
			{
				throw new Exception("User not found.");
			}

			// connect it
			foreach(var symbol in symbols)
			{
				var ticker = await tickersContext.Tickers.Where(x => x.Symbol.Equals(symbol)).FirstOrDefaultAsync();

				var userTicker = new UserTickerDTO()
				{
					Ticker = ticker,
					TickerId = ticker.Id,
					User = user,
					UserId = user.Id
				};

				tickersContext.Add(userTicker);
			}

			try
			{
				await tickersContext.SaveChangesAsync();
			}
			catch(Exception e)
			{
				// log here
				throw;
			}
		}

		public async Task<bool> ExistsTickerConnection(string symbol)
		{
			var userTickers = await tickersContext.UserTickers.Include(x => x.Ticker).Where(x => x.Ticker.Symbol.Equals(symbol)).ToListAsync();
			if (userTickers.Count() > 0) return true;

			return false;
		}

		public async Task<IEnumerable<string>> GetUserTickers(string username)
		{
			return await tickersContext.Users.Where(x => x.Username.Equals(username))
				.SelectMany(x => x.UserTickers.Select(y => y.Ticker.Symbol))
				.ToListAsync();
		}

		public async Task RemoveTicker(string symbol)
		{
			var ticker = await tickersContext.Tickers.Where(x => x.Symbol.Equals(symbol)).FirstOrDefaultAsync();
			tickersContext.Tickers.Remove(ticker);

			try
			{
				await tickersContext.SaveChangesAsync();
			}
			catch(Exception e)
			{
				throw;
			}
		}

		public async Task RemoveUserTickers(string username, string[] symbols)
		{
			foreach (var symbol in symbols)
			{
				// TODO: do not do it in for, query all userTickers
				var userTicker = await tickersContext.UserTickers.Include(x => x.Ticker).Include(x => x.User)
					.Where(x => x.User.Username.Equals(username) && x.Ticker.Symbol.Equals(symbol)).FirstOrDefaultAsync();

				tickersContext.Remove(userTicker);
			}

			try
			{
				await tickersContext.SaveChangesAsync();
			}
			catch(Exception e)
			{
				throw;
			}
			
		}

		private async Task CreateTickers(string[] symbols)
		{
			foreach(var symbol in symbols)
			{
				var ticker = new TickerDTO()
				{
					Symbol = symbol
				};
				tickersContext.Add(ticker);
			}

			try
			{
				await tickersContext.SaveChangesAsync();
			}
			catch(Exception e)
			{
				// log here
				throw;
			}
			
		}
	}
}
