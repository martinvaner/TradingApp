using Downloader.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Downloader.Application.Services
{
	public class DownloadService : IDownloadService
	{

		public DownloadService()
		{

		}

		public async Task RegisterBackgroudDataDownload(double interval)
		{
			
			var timer = new Timer(interval);
			timer.Elapsed += RunBackgroundDataDownload; // TODO: shouldnt be there await?
			timer.Start();
		}

		private void RunBackgroundDataDownload(object sender, ElapsedEventArgs eventArgs)
		{
			// get latest data


			// add latest price
			// delete oldest price
			// recompute SME
			// raise event that will get FE know about change of data
		}
	}
}
