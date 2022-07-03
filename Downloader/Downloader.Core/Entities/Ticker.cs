using System;

namespace Downloader.Core.Entities
{
	public class Ticker
	{
		public string Symbol { get; set; }
		public DateTime Date { get; set; }
		public Price[] Prices { get; set; }
	}
}
