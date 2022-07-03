using System;
using System.Text.Json.Serialization;

namespace Downloader.Infrastructure.DTOs
{
	public class TickerDTO
	{
		public string Symbol { get; set; }
		public DateTime Date { get; set; }

		[JsonPropertyName("prices")]
		public PriceDTO[] Prices { get; set; }
	}
}
