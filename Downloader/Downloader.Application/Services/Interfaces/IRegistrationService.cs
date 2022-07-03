using Downloader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Application.Services.Interfaces
{
	/// <summary>
	/// Service for registration of new tickers 
	/// </summary>
	public interface IRegistrationService
	{
		Task RegisterTicker(string tickerName);
		Task RegisterTickers(IEnumerable<string> tickersNames);
	}
}
