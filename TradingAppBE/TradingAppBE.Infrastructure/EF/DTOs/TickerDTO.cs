using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAppBE.Infrastructure.EF.DTOs
{
	public class TickerDTO
	{
		public int Id { get; set; }
		public string Symbol { get; set; }

		public ICollection<UserTickerDTO> UserTickers { get; set; } = new List<UserTickerDTO>();
	}
}
