using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TradingAppBE.DTOs
{
	public class MovingAverageDTO
	{
		[JsonPropertyName("sma200")]
		public decimal SMA200 { get; set; }
		[JsonPropertyName("sma50")]
		public decimal SMA50 { get; set; }
	}
}
