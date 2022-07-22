using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;

namespace TrradingAppBE.Application.Repository.Interfaces
{
	public interface IDownloaderApiRepository
	{
		/// <summary>
		/// Get data from downloader by ticker symbol.
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<Ticker> Get(string symbol);
	}
}
