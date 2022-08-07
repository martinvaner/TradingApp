using Downloader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Application.Services.Interfaces
{
	public interface IDownloadService
	{
		Task<Ticker> DownloadData(string symbol);

		Task< IEnumerable<Ticker> > Subscribe(string[] symbols);
	}
}
