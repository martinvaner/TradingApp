using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Application.Services.Interfaces
{
	/// <summary>
	/// Service for periodic data updating
	/// </summary>
	public interface IDownloadService
	{
		Task RegisterBackgroudDataDownload(double timeSpan);
	}
}
