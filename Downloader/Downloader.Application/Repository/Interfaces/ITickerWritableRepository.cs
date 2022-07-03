using Downloader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Application.Repository.Interfaces
{
	public interface ITickerWritableRepository : ITickerRepository
	{
		/// <summary>
		/// Write data
		/// </summary>
		/// <param name="ticker"></param>
		/// <returns></returns>
		Task Write(Ticker ticker);
	}
}
