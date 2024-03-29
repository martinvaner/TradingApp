﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;

namespace TrradingAppBE.Application.Services.Interfaces
{
	public interface IDataService
	{
		/// <summary>
		/// Get ticker based on ticker symbol
		/// </summary>
		/// <param name="symbol">Ticker symbol</param>
		/// <returns></returns>
		Task<Ticker> GetTickerData(string symbol);

		/// <summary>
		/// Get tickers that are subscribed by user
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		Task<IEnumerable<Ticker>> GetUserTickers(string username);

		Task<IEnumerable<Ticker>> CreateUserTickers(string username, string[] symbols);

		Task RemoveUserTickers(string username, string[] symbols);
	}
}
