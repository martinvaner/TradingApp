using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAppBE.Infrastructure.EF.DTOs
{
	public class UserTickerDTO
	{
		public TickerDTO Ticker { get; set; }
		public int TickerId { get; set; }

		public UserDTO User { get; set; }
		public int UserId { get; set; }
	}
}
