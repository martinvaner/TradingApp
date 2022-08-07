using System;
using System.Collections.Generic;

namespace TradingAppBE.Infrastructure.EF.DTOs
{
	public class TickerDTO
	{
		public int Id { get; set; }
		public string Symbol { get; set; }

		public ICollection<UserTickerDTO> UserTickers { get; set; } = new List<UserTickerDTO>();
	}
}
