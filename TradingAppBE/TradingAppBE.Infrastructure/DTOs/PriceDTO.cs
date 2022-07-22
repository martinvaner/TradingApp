using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TradingAppBE.Infrastructure.DTOs
{
	public class PriceDTO
	{
		[JsonPropertyName("close")]
		public decimal Close { get; set; }
	}
}
