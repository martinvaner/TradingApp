using Downloader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Application.Repository.Interfaces
{
	/// <summary>
	/// Repository for getting ticker data 
	/// </summary>
	public interface ITickerRepository
	{
		/// <summary>
		/// Get data by key
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		Task<Ticker> Get(string tickerName);
	}
}
