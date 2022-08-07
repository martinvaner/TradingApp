using System;
using System.Collections.Generic;

namespace TradingAppBE.Infrastructure.EF.DTOs
{
	public class UserDTO
	{
		public int Id { get; set; }
		public string Username { get; set; }

		public ICollection<UserTickerDTO> UserTickers { get; set; } = new List<UserTickerDTO>();
	}
}
