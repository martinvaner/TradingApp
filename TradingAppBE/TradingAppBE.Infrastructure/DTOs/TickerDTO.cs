using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TradingAppBE.Infrastructure.DTOs
{
	public class TickerDTO
	{
		[JsonPropertyName("symbol")]
		public string Symbol { get; set; }
		[JsonPropertyName("date")]
		public DateTime Date { get; set; }
		[JsonPropertyName("prices")]
		public PriceDTO[] Prices { get; set; }
	}
}
