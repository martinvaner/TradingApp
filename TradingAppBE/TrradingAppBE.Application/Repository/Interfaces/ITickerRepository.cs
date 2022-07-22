using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;

namespace TrradingAppBE.Application.Repository.Interfaces
{
	public interface ITickerRepository
	{
		Task<Ticker> Get(string symbol);
	}
}
